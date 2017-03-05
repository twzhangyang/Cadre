using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CadreManagement.Core.ServiceBus
{
    public class SyncHandlerInvoker
    {
        public static ConcurrentDictionary<Type, List<ActionReference>> MessageHandlerActions =
            new ConcurrentDictionary<Type, List<ActionReference>>();

        public void Invoke(object handler, object message)
        {
            var messageType = message.GetType();
            var handlerType = handler.GetType();
            List<ActionReference> actionReferences;
            if (!MessageHandlerActions.TryGetValue(handlerType, out actionReferences))
            {
                actionReferences = CreateActions(handlerType);
            }

            foreach (var actionReference in actionReferences)
            {
                if (actionReference.MessageType.IsAssignableFrom(messageType))
                {
                    actionReference.Action.Invoke(handler, message);
                }
            }
        }

        private List<ActionReference> CreateActions(Type targetType)
        {
            var interfaceArguments = targetType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandleMessage<>))
                .Select(i => i.GetGenericArguments().First());

            var actionReferences = new List<ActionReference>();
            foreach (var messageType in interfaceArguments)
            {
                var action = CreateMethodInvokeAction(targetType, messageType);
                actionReferences.Add(new ActionReference(messageType, action));
            }

            return actionReferences;
        }

        private Action<object, object> CreateMethodInvokeAction(Type targetType, Type messageType)
        {
            var interfaceType = typeof(IHandleMessage<>).MakeGenericType(messageType);

            if (interfaceType.IsAssignableFrom(targetType))
            {
                var methodInfo = targetType.GetInterfaceMap(interfaceType).TargetMethods.FirstOrDefault();
                if (methodInfo != null)
                {
                    var target = Expression.Parameter(typeof(object));
                    var param = Expression.Parameter(typeof(object));

                    var castTarget = Expression.Convert(target, targetType);
                    var castParam = Expression.Convert(param, methodInfo.GetParameters().First().ParameterType);
                    var execute = Expression.Call(castTarget, methodInfo, castParam);
                    return Expression.Lambda<Action<object, object>>(execute, target, param).Compile();
                }
            }

            return null;
        }

        public class ActionReference
        {
            public ActionReference(Type messageType, Action<object, object> action)
            {
                MessageType = messageType;
                Action = action;
            }

            public Type MessageType { get; set; }
            public Action<object, object> Action { get; set; }
        }
    }
}