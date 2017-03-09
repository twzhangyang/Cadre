using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Http;
using CadreManagement.Core.Extensions;

namespace CadreManagement.Web.HyperMediaApi
{
    public class RouteValueExtractor
    {
        public class RouteParameters
        {
            public string RouteName = null;
            public readonly Dictionary<string, ArgumentPlaceHolder> ArgumentPlaceholders = new Dictionary<string, ArgumentPlaceHolder>();
            public string Controller { get { return RouteValueDictionary["controller"].ToString(); } }
            public string Action { get { return RouteValueDictionary["action"].ToString(); } }
            public readonly Dictionary<string, object> RouteValueDictionary = new Dictionary<string, object>();
        }

        public class ArgumentPlaceHolder
        {
            private readonly IDictionary<string, object> _routeValueDictionary;
            private readonly ArgumentSpec _argument;

            public readonly int Index = -1;
            public string Name { get; private set; }

            public object Value { get { return _routeValueDictionary[Name]; } set { _routeValueDictionary[Name] = value; } }

            internal ArgumentPlaceHolder(
                int index,
                IDictionary<string, object> routeValueDictionary,
                ArgumentSpec argument)
            {
                _routeValueDictionary = routeValueDictionary;
                _argument = argument;

                Index = index;
                Name = _argument.ParameterName;
                Value = GetPlaceHolderValue();
            }

            private object GetPlaceHolderValue()
            {
                if (_argument.Argument.Type == typeof(string))
                {
                    return "1CD87227-A762-468C-95DB-1EFF63452161{0}".FormatWith(Index);
                }
                if (_argument.Argument.Type == typeof(int))
                {
                    return int.MinValue + 333 + Index;
                }
                if (_argument.Argument.Type == typeof(Guid))
                {
                    return Guid.Parse("00000000-0000-0000-0000-00000000000{0}".FormatWith(Index));
                }
                if(_argument.Argument.Type.IsGenericType && _argument.Argument.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    return "B68F625D-387A-46C8-8697-FB2B31138B24{0}".FormatWith(Index);
                }

                throw new NotImplementedException("No support yet for template arguments of type: {0}".FormatWith(_argument.Argument.Type));
            }
        }

        public static RouteParameters ExtractRouteParameters<TController, TResult>(Expression<Func<TController, TResult>> actionSelector)
             where TController : ApiController
        {
            return ExtractHttpRouteParameters<TController>(actionSelector);
        }

        public static RouteParameters ExtractRouteParameters<TController, TArgument1, TResult>(
            Expression<Func<TController, TArgument1, TResult>> actionSelector) where TController : ApiController
        {
            return ExtractHttpRouteParameters<TController>(actionSelector);
        }

        public static RouteParameters ExtractRouteParameters<TController, TArgument1, TArgument2, TResult>(
            Expression<Func<TController, TArgument1, TArgument2, TResult>> actionSelector) where TController : ApiController
        {
            return ExtractHttpRouteParameters<TController>(actionSelector);
        }

        public static RouteParameters ExtractMvcRouteParameters<TController>(LambdaExpression callControllerMethod)
        {
            var routeValues = ExtractCommonRouteValues<TController>(callControllerMethod);

            return routeValues;
        }        

        public static RouteParameters ExtractHttpRouteParameters<TController>(LambdaExpression callControllerMethod) where TController : ApiController
        {
            var routeValues = ExtractCommonRouteValues<TController>(callControllerMethod);
            routeValues.RouteName = GetRouteName<TController>(callControllerMethod);
            return routeValues;
        }

        internal class ArgumentSpec
        {
            public int Index { get; set; }
            public Expression Argument { get; set; }
            public string ParameterName { get; set; }
        }

        private static ArgumentSpec[] GetArguments(MethodCallExpression controllerMethodCall)
        {
            return controllerMethodCall.Arguments.Select((a, i) => new
            ArgumentSpec
            {
                Index = i,
                Argument = a,
                ParameterName = controllerMethodCall.Method.GetParameters()[i].Name
            }).ToArray();
        }

        private static RouteParameters ExtractCommonRouteValues<TController>(LambdaExpression callControllerMethod)
        {
            var routeValues = new RouteParameters();

            var controllerMethodCall = ExtractControllerMethodCall<TController>(callControllerMethod);

            routeValues.RouteValueDictionary["controller"] = GetControllerName<TController>();
            routeValues.RouteValueDictionary["action"] = controllerMethodCall.Method.Name;

            var templateArgumentCount = 0;
            foreach (var argument in GetArguments(controllerMethodCall))
            {
                if (argument.Argument.NodeType == ExpressionType.Parameter) //This is a template argument
                {
                    routeValues.ArgumentPlaceholders[argument.ParameterName] = new ArgumentPlaceHolder(
                        templateArgumentCount++,
                        routeValues.RouteValueDictionary,
                        argument);
                }
                else
                {
                    routeValues.RouteValueDictionary.Add(argument.ParameterName, argument.Argument.GetValue());
                }
            }
            return routeValues;
        }

        private static string GetControllerName<TController>()
        {
            var controllerType = typeof(TController);
            return controllerType.Name.EndsWith("Controller")
                ? controllerType.Name.Substring(0, controllerType.Name.Length - "Controller".Length)
                : controllerType.Name;
        }

        private static string GetRouteName<TController>(LambdaExpression callControllerMethod)
        {
            var controllerMethodCall = ExtractControllerMethodCall<TController>(callControllerMethod);

            var methodRouteAttribute = controllerMethodCall.Method.GetCustomAttributes(typeof(RouteAttribute)).OfType<RouteAttribute>().ToList();

            if (methodRouteAttribute.Any())
            {
                var routeAttribute = methodRouteAttribute.Single();
                var routeName = routeAttribute.Name;
                if (!routeName.IsNullOrEmpty())
                {
                    return routeName;
                }
            }

            throw new Exception("Api controller methods are required to have a RouteAttribute with the name property specified");
        }

        private static MethodCallExpression ExtractControllerMethodCall<TController>(LambdaExpression actionSelector)
        {
            var controllerType = typeof(TController);
            var call = actionSelector.Body as MethodCallExpression;
            if (call == null)
            {
                throw new ArgumentException("You must call a method of " + controllerType.Name, "actionSelector");
            }

            //the object being called must be the controller specified in <TController>
            if (call.Object.Type != controllerType)
            {
                throw new ArgumentException("You must call a method of " + controllerType.Name, "actionSelector");
            }
            return call;
        }
    }
}