using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Text;
using ORM.Atributy;

namespace ORM
{
    public class ReflectiveOrm<T> where T : class
    {
        private readonly SqlConnection _connection;
        private bool _isId;
        public string Condition { get; set; }

        public ReflectiveOrm(SqlConnection sqlConnection)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                throw new Exception("Connection closed");

            _connection = sqlConnection;
            
        }
        public IEnumerable<T> JoinedSelect()
        {
            var entityType = typeof(T);
            var tables = GetTable(typeof(T));
            var columns = new List<string>();
            var properties = entityType.GetProperties();
            var join = new StringBuilder();
            foreach (var property in properties)
            {
                string column;
                
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    var innerTables = GetTable(property.PropertyType);
                    var innerProperties = property.PropertyType.GetProperties();
                    foreach (var innerProperty in innerProperties)
                    {
                        column = GetColumn(innerProperty,true);
                        var check2 = innerTables + "." + column;
                        if (!(columns.Contains(check2)))
                        {
                            columns.Add(innerTables + "." + column);
                        }
                        else
                        {
                            columns.Add("k1" + "." + column);
                        }
                        
                        var check = innerTables + "." + column;

                        if (!(join.ToString().Contains(check)))
                        {
                            if (_isId)
                            {
                                join.Append($"JOIN {innerTables} ON {innerTables}.{column} = {tables}.{column} ");
                                _isId = false;
                            }
                        }
                        else
                        {
                            join.Append($"JOIN {innerTables} k1 ON k1.{column} = {tables}.{column}1 ");
                            _isId = false;
                        }
                    }

                    continue;
                }

                column = GetColumn(property);

                if (column != null)
                {
                    columns.Add(tables + "." + column);
                }
            }
            
            var statement = BuildCommandJoinedSelect(columns, join.ToString(),tables,Condition);

            return SelectJoinedEntities(columns, statement);
        }

        public IEnumerable<T> Select()
        {
            var entityType = typeof(T);

            var columns = new List<string>();
            var tables = GetTable(entityType);

            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    continue;
                }
                var column = GetColumn(property, true);

                if (column != null)
                {
                    columns.Add(column);
                }
            }

            var statement = BuildCommandSelect(columns, tables, Condition);

            return SelectEntities(statement, columns, entityType, properties);
        }

        public void Insert(object entity)
        {
            var entityType = typeof(T);

            var tableName = GetTable(entityType);

            var props = entityType.GetProperties();

            var columns = new StringBuilder().Append("(");
            var values = new StringBuilder().Append("(");

            foreach (var prop in props)
            {
                InsertArgs(entity, prop, values, columns);
            }
            
            columns.Remove(columns.Length - 1, 1).Append(')');
            values.Remove(values.Length - 1, 1).Append(')');
            
            using var sqlCommand = new SqlCommand(BuildCommandInsert(tableName, columns.ToString(), values.ToString()), _connection);
            sqlCommand.ExecuteNonQuery();

        }

        public void Update(object entity)
        {
            var entityType = typeof(T);

            var tableName = GetTable(entityType);
            var props = entityType.GetProperties();
            StringBuilder arguments = new StringBuilder();

            foreach (var prop in props)
            {
                UpdateArgs(entity, prop, arguments);
            }
            arguments.Remove(arguments.Length - 1, 1);
            
            using var sqlCommand = new SqlCommand(BuildCommandUpdate(tableName, arguments.ToString(), Condition), _connection);
            sqlCommand.ExecuteNonQuery();
        }

        public void Delete()
        {
            var entityType = typeof(T);
            var tableName = GetTable(entityType);

            using var sqlCommand = new SqlCommand(BuildCommandDelete(Condition, tableName), _connection);
            sqlCommand.ExecuteNonQuery();
            
        }

        private void InsertArgs(object entity, PropertyInfo prop, StringBuilder values, StringBuilder columns)
        {
            var column = GetColumn(prop,false,true);
            if (column == null) return;
            if (prop.GetValue(entity) == null) values.Append("NULL,");
            
            else if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
            {
                var innerProp = prop.PropertyType.GetProperties();
                var instance = prop.GetValue(entity);
                
                foreach (var innerProperty in innerProp)
                {
                    var atbs = innerProperty.GetCustomAttributes();

                    foreach (var atb in atbs)
                    {
                        if (atb is KeyAttribute)
                        {
                            var currentcolumn = GetColumn(innerProperty, true);
                            columns.Append(currentcolumn + ",");
                            var value = innerProperty.GetValue(instance);
                            values.Append(prop.PropertyType == typeof(string) ? $"'{value}'," : $"{value},");
                        }
                    }
                }
            }
            else
            {
                values.Append(prop.PropertyType == typeof(string) ? $"'{prop.GetValue(entity)}'," : $"{prop.GetValue(entity)},");
            }

            var foreignAtt = prop.GetCustomAttributes();
            
            if (!(foreignAtt.ToList()[0] is ForeignKeyAttribute))
                columns.Append(column + ",");
        }

        private void UpdateArgs(object entity, PropertyInfo prop, StringBuilder values)
        {
            var column = GetColumn(prop, false, true);
            if (column == null) return;
            
            if (prop.GetValue(entity) == null)
            {
                values.Append($"{GetColumn(prop)} = NULL,");
            }
            
            else if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
            {
                var innerProp = prop.PropertyType.GetProperties();
                var instance = prop.GetValue(entity);

                foreach (var innerProperty in innerProp)
                {
                    var atbs = innerProperty.GetCustomAttributes();

                    foreach (var atb in atbs)
                    {
                        if (atb is KeyAttribute)
                        {
                            var currentcolumn = GetColumn(innerProperty, true);
                            var val = innerProperty.GetValue(instance);
                            values.Append(prop.PropertyType == typeof(string) ? $"{currentcolumn} = '{val}'," : $"{currentcolumn} = {val},");
                        }
                    }
                }
            }
            
            else
            {
                values.Append(prop.PropertyType == typeof(string) ? $"{column} = '{prop.GetValue(entity)}'," : $"{column} = {prop.GetValue(entity)},");
            }
        }
        
        private IEnumerable<T> SelectEntities(string sqlStatement, IReadOnlyList<string> columnNames, Type entityType, PropertyInfo[] entiPropertyInfos)
        {
            var dictionary = new Dictionary<string, object>();
            List<T> entities = new List<T>();

            using (var sqlCommand = new SqlCommand(sqlStatement, _connection))
            {
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        for (int i = 0; i < columnNames.Count; i++)
                        {
                            dictionary.Add(columnNames[i], sqlReader.GetValue(i));
                        }

                        var entity = Activator.CreateInstance(entityType);

                        foreach (var entityProperty in entiPropertyInfos)
                        {
                            if (entityProperty.PropertyType.IsClass && entityProperty.PropertyType != typeof(string))
                            {
                                continue;
                            }
                            var currentColumn = GetColumn(entityProperty, true);
                            entityProperty.SetValue(entity, dictionary[currentColumn] == DBNull.Value ? null : dictionary[currentColumn]);
                        }

                        entities.Add((T)entity);

                        dictionary.Clear();
                    }
                }
            }

            return entities;
        }

        private static string GetTable(MemberInfo type)
        {
            var attributes = type.GetCustomAttributes();
            return attributes.ToList()[0].ToString();
        }

        private IEnumerable<T> SelectJoinedEntities(IReadOnlyList<string> columnNames,string statement)
        {
            var hraci = new List<T>();
            
            var dictionary = new Dictionary<string, object>();
            using (var sqlCommand = new SqlCommand(statement, _connection))
            {
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        for (int i = 0; i < columnNames.Count; i++)
                        {
                            var names = columnNames[i].Split('.')[1];

                            if (!(dictionary.ContainsKey(names)))
                            {
                                dictionary.Add(names, sqlReader.GetValue(i));
                            }
                            else
                            {
                                dictionary.Add(names+"1", sqlReader.GetValue(i));
                            }
                        } 
                        
                        var entity = Activator.CreateInstance(typeof(T));
                        var entityType = typeof(T);
                        var properties = entityType.GetProperties();
                        int counter = 0;
                        
                        var propsis = new List<Type>();
                        
                        foreach (var entityProperty in properties)
                        {
                            if (entityProperty.PropertyType.IsClass && entityProperty.PropertyType != typeof(string))
                            {
                                if (!propsis.Contains(entityProperty.PropertyType))
                                {
                                    propsis.Add(entityProperty.PropertyType);
                                }
                                else
                                {
                                    counter++;
                                }
                                
                                var innerEntity = Activator.CreateInstance(entityProperty.PropertyType);
                                var innerType = entityProperty.PropertyType;
                                var innnerProperties = innerType.GetProperties();
                                foreach (var innnerProperty in innnerProperties)
                                {
                                   
                                    var currentColumn = GetColumn(innnerProperty);
                                    if (counter > 0)
                                    {
                                        currentColumn += $"{counter}";
                                    }
                                    innnerProperty.SetValue(innerEntity,
                                        dictionary[currentColumn] == DBNull.Value ? null : dictionary[currentColumn]);
                                }
                                entityProperty.SetValue(entity, innerEntity);
                                
                            }

                            else
                            {
                                var currentColumn = GetColumn(entityProperty);
                                entityProperty.SetValue(entity,
                                    dictionary[currentColumn] == DBNull.Value
                                        ? null
                                        : dictionary[currentColumn]);
                            }
                        }
                        
                        hraci.Add((T) entity);
                        
                        dictionary.Clear();
                    }
                }
            }

            Condition = null;
            return hraci;
        }

        private string GetColumn(MemberInfo entityPropertyInfo, bool inner = false, bool getWithoutId = false)
        {
            var propertyAttributes = entityPropertyInfo.GetCustomAttributes();

            foreach (var propertyAttribute in propertyAttributes)
            {
                switch (propertyAttribute)
                {
                    
                    case KeyAttribute _ :
                        if (getWithoutId)
                        {
                            return default;
                        }

                        if (!inner) continue;
                        _isId = true;
                        break;
                    case ColumnName columnAttribute:
                        return columnAttribute.Name;
                }
            }
            return entityPropertyInfo.Name;
        }

        private static string BuildCommandUpdate(string tableName, string arguments, string condition)
        {
            return $"UPDATE {tableName} SET {arguments} {condition}";
        }

        private static string BuildCommandInsert(string tableName, string columns, string values)
        {
            return $"INSERT INTO " + tableName + columns + "VALUES" + values;
        }

        private static string BuildCommandSelect(IEnumerable<string> col, string tableName, string condition)
        {
            return "SELECT " + string.Join(",", col) + " FROM " + tableName + " " + condition;
        }

        private static string BuildCommandDelete(string condition, string tableName)
        {
            return $"DELETE FROM {tableName} {condition}";
        }

        private static string BuildCommandJoinedSelect(IEnumerable<string> columns, string join, string table, string condition)
        {
            var command = $"SELECT {string.Join(",", columns)} from {table} {join} {condition}";
            return command;
        }
    }
}
