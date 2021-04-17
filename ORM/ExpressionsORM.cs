using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ORM.Atributy;

namespace ORM
{
    public static class ExpressionsOrm
    {
        public static ReflectiveOrm<T> Where<T>(this ReflectiveOrm<T> @this, Expression<Func<T, bool>> expression) where T : class
        {

            MemberExpression right = (MemberExpression) ((BinaryExpression) expression.Body).Left;

            var tablename = right.Expression.Type.GetCustomAttributes(typeof(TableName)).ToList()[0];
            
            var klub = right.Expression.ToString();

            var check = klub.Contains("Klub2");

            if (check)
            {
                @this.Condition ??= $"WHERE k1.{Convert(expression)} ";
                return @this;
            }

            @this.Condition ??= $"WHERE {tablename}.{Convert(expression)} ";
            return @this;
        }

        private static string Operator(ExpressionType expressionType)
        {

            var dictionary = new Dictionary<ExpressionType, string>
            {
                [ExpressionType.Equal] = "=",
                [ExpressionType.NotEqual] = "!=",
                [ExpressionType.LessThan] = "<",
                [ExpressionType.LessThanOrEqual] = "<=",
                [ExpressionType.GreaterThan] = ">",
                [ExpressionType.GreaterThanOrEqual] = ">=",
                [ExpressionType.AndAlso] = "AND",
                [ExpressionType.OrElse] = "OR"
            };


            return dictionary[expressionType];
        }

        private static string Convert(Expression expression)
        {
            var lambdaExpression = (LambdaExpression)expression;
            
            var expressionBody = (BinaryExpression)lambdaExpression.Body;

            return InternalConvert(expressionBody.Left, "left") + " " + Operator(expressionBody.NodeType) + " " + InternalConvert(expressionBody.Right, "right");
        }

        private static string InternalConvert(Expression expressionSide, string side)
        {
            switch (expressionSide)
            {
                case MethodCallExpression _:
                    throw new SystemException();
                case BinaryExpression binaryExpression:
                    return InternalConvert(binaryExpression.Left, "left") + " " + Operator(binaryExpression.NodeType) + " " + InternalConvert(binaryExpression.Right, "right");
            }
            
            switch (expressionSide)
            {
                case MemberExpression propertyExpression:
                    {
                        var propertyColumnAttribute = propertyExpression.Member.GetCustomAttribute(typeof(ColumnName));
                        var propertyName = propertyColumnAttribute == null ? propertyExpression.Member.Name : (propertyColumnAttribute as ColumnName)?.Name;

                        if (side != "right") return propertyName;
                        
                        var objectM = Expression.Convert(propertyExpression, typeof(object));
                        var lambda = Expression.Lambda<Func<object>>(objectM);
                        var getter = lambda.Compile();
                        var value = getter();

                        switch (value)
                        {
                            case int _:
                            case double _:
                            case float _:
                                return $"{value}";
                            case string _:
                                return $"'{value}'";
                        }

                        return propertyName;
                    }
                
                default:
                    return null;
            }
        }
    }
}
