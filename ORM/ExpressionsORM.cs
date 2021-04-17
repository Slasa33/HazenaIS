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
                if (@this.ConditionSql == null) 
                    @this.ConditionSql = $"WHERE k1.{TranslateExpression(expression)} ";
            
                else 
                    @this.ConditionSql += $"AND {TranslateExpression(expression)} ";
            
                return @this;
            }
            else
            {

                if (@this.ConditionSql == null)
                    @this.ConditionSql = $"WHERE {tablename}.{TranslateExpression(expression)} ";

                else
                    @this.ConditionSql += $"AND {TranslateExpression(expression)} ";

                return @this;
            }
        }

        private static string CreateStringOperator(ExpressionType expressionType)
        {

           var translate = new Dictionary<ExpressionType, string>();
            
            translate[ExpressionType.Equal] = "=";
            translate[ExpressionType.NotEqual] = "!=";
            translate[ExpressionType.GreaterThan] = ">";
            translate[ExpressionType.GreaterThanOrEqual] = ">=";
            translate[ExpressionType.LessThan] = "<";
            translate[ExpressionType.LessThanOrEqual] = "<=";
            translate[ExpressionType.AndAlso] = "AND";
            translate[ExpressionType.OrElse] = "OR";
            
            return translate[expressionType];
        }

        public static string TranslateExpression(Expression expression)
        {
            if (!(expression is LambdaExpression))
                throw new SystemException();

            var lambdaExpression = (LambdaExpression)expression;

            if (!(lambdaExpression.Body is BinaryExpression))
                throw new SystemException();

            var expressionBody = (BinaryExpression)lambdaExpression.Body;

            return InternalTranslateSide(expressionBody.Left, "left") + " " + CreateStringOperator(expressionBody.NodeType) + " " + InternalTranslateSide(expressionBody.Right, "right");
        }

        private static string InternalTranslateSide(Expression expressionSide, string side)
        {
            if (expressionSide is MethodCallExpression)
                throw new SystemException();
            
            if (expressionSide is BinaryExpression binaryExpression)
            {
                return InternalTranslateSide(binaryExpression.Left, "left") + " " +
                       CreateStringOperator(binaryExpression.NodeType) + " " +
                       InternalTranslateSide(binaryExpression.Right, "right");
            }

            
            if (!(expressionSide is MemberExpression || expressionSide is ConstantExpression))
                throw new Exception();

            switch (expressionSide)
            {
                case MemberExpression propertyExpression:
                    {
                        var propertyColumnAttribute = propertyExpression.Member.GetCustomAttribute(typeof(ColumnName));
                        var propertyName = propertyColumnAttribute == null ?
                            propertyExpression.Member.Name :
                            (propertyColumnAttribute as ColumnName)?.Name;

                        if (side == "right")
                        {
                            var objectM = Expression.Convert(propertyExpression, typeof(object));

                            var lambda = Expression.Lambda<Func<object>>(objectM);

                            var getter = lambda.Compile();

                            var value = getter();

                            if (value is int || value is double || value is float)
                                return $"{value}";

                            if (value is string)
                                return $"'{value}'";
                        }

                        return propertyName;
                    }

                case ConstantExpression constantExpression:
                    {
                        return constantExpression.Type != typeof(int) ? $"'{constantExpression.Value}'" : constantExpression.ToString();
                    }

                default:
                    return null;
            }
        }
    }
}
