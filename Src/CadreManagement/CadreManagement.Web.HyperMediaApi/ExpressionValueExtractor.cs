using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CadreManagement.Web.HyperMediaApi
{
    public static class ExpressionValueExtractor
    {
        public static object GetValue(this Expression expression)
        {
            return GetExpressionValue(expression, null, null);
        }

        private static object GetExpressionValue(Expression expression, ReadOnlyCollection<ParameterExpression> parameters, object[] parameterValues)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                    return ((ConstantExpression)expression).Value;
                case ExpressionType.MemberAccess:
                    {
                        var me = (MemberExpression)expression;
                        object obj = (me.Expression != null ? GetExpressionValue(me.Expression, parameters, parameterValues) : null);
                        if (me.Member is FieldInfo)
                            return ((FieldInfo)me.Member).GetValue(obj);
                        else if (me.Member is PropertyInfo)
                            return ((PropertyInfo)me.Member).GetValue(obj, null);
                        else
                            throw new NotSupportedException("Unsupported member access type");
                    }
                case ExpressionType.Parameter:
                    {
                        var pe = (ParameterExpression)expression;
                        for (int i = 0; i < parameters.Count; i++)
                        {
                            if (pe.Name == parameters[i].Name)
                                return parameterValues[i];
                        }
                        throw new InvalidOperationException("Invalid parameter");
                    }
                case ExpressionType.Convert:
                    {
                        var ue = (UnaryExpression)expression;
                        var operand = GetExpressionValue(ue.Operand, parameters, parameterValues);
                        if (ue.Type.IsInstanceOfType(operand))
                        {
                            return operand;
                        }
                        if (ue.Type.IsGenericType && ue.Type.GetGenericTypeDefinition() == typeof(Nullable<>) && ue.Type.GetGenericArguments()[0] == ue.Operand.Type)
                            return Activator.CreateInstance(typeof(Nullable<>).MakeGenericType(ue.Operand.Type), operand);
                        else
                            return Convert.ChangeType(operand, ue.Type);
                    }
                case ExpressionType.Call:
                    {
                        var ce = (MethodCallExpression)expression;
                        var target = (ce.Object != null ? GetExpressionValue(ce.Object, parameters, parameterValues) : null);
                        var args = ce.Arguments.Select(a => GetExpressionValue(a, parameters, parameterValues)).ToArray();
                        return ce.Method.Invoke(target, args);
                    }
                default:
                    return SlowFallbackToCompilingAndExecutingLambda(expression);
            }
        }

        private static object SlowFallbackToCompilingAndExecutingLambda(Expression expression)
        {
            //throw new NotSupportedException("The expression is not supported");
            // We can do this, but performance is REALLY bad (so bad that it actually matters).
            return Expression.Lambda(expression).Compile().DynamicInvoke(null);
        }
    }
}