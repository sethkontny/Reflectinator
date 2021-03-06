﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Reflectinator
{
    public static partial class ExpressionFactory
    {
        #region Field

        public static Expression<Func<object, object>> CreateGetValueFuncExpression(FieldInfo fieldInfo)
        {
            return CreateGetValueFuncExpression<object, object>(fieldInfo);
        }

        public static Expression<Func<TInstanceType, TReturnType>> CreateGetValueFuncExpression<TInstanceType, TReturnType>(FieldInfo fieldInfo)
        {
            var instanceParameter = Expression.Parameter(typeof(TInstanceType), "instance");

            var field = GetField(fieldInfo, typeof(TInstanceType), instanceParameter);

            var body = field.Coerce(fieldInfo.FieldType, typeof(TReturnType));

            var expression = Expression.Lambda<Func<TInstanceType, TReturnType>>(body, string.Format("<get>_{0}.{1}", fieldInfo.DeclaringType.Name, fieldInfo.Name), new []{ instanceParameter });
            return expression;
        }

        public static Expression<Func<object>> CreateStaticGetValueFuncExpression(FieldInfo fieldInfo)
        {
            return CreateStaticGetValueFuncExpression<object>(fieldInfo);
        }

        public static Expression<Func<TReturnType>> CreateStaticGetValueFuncExpression<TReturnType>(FieldInfo fieldInfo)
        {
            var field = Expression.Field(null, fieldInfo);
            var body = field.Coerce(fieldInfo.FieldType, typeof(TReturnType));

            var expression = Expression.Lambda<Func<TReturnType>>(body, string.Format("<get>_{0}.{1}", fieldInfo.DeclaringType.Name, fieldInfo.Name), Enumerable.Empty<ParameterExpression>());
            return expression;
        }

        public static Expression<Action<object, object>> CreateSetValueFuncExpression(FieldInfo fieldInfo)
        {
            return CreateSetValueFuncExpression<object, object>(fieldInfo);
        }

        public static Expression<Action<TInstanceType, TValueType>> CreateSetValueFuncExpression<TInstanceType, TValueType>(FieldInfo fieldInfo)
        {
            var instanceParameter = Expression.Parameter(typeof(TInstanceType), "instance");
            var valueParameter = Expression.Parameter(typeof(TValueType), "value");

            Expression body;

            if (!fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
            {
                var field = GetField(fieldInfo, typeof (TInstanceType), instanceParameter);

                var valueCast = valueParameter.Coerce(typeof (TValueType), fieldInfo.FieldType);
                body = Expression.Assign(field, valueCast);
            }
            else
            {
                body = GetThrowMemberAccessExceptionExpression(fieldInfo, "write to");
            }

            var expression = Expression.Lambda<Action<TInstanceType, TValueType>>(body, string.Format("<set>_{0}.{1}", fieldInfo.DeclaringType.Name, fieldInfo.Name), new[] { instanceParameter, valueParameter });
            return expression;
        }

        public static Expression<Action<object>> CreateStaticSetValueActionExpression(FieldInfo fieldInfo)
        {
            return CreateStaticSetValueActionExpression<object>(fieldInfo);
        }

        public static Expression<Action<TValueType>> CreateStaticSetValueActionExpression<TValueType>(FieldInfo fieldInfo)
        {
            var valueParameter = Expression.Parameter(typeof(TValueType), "value");

            Expression body;

            if (!fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
            {
                var valueCast = valueParameter.Coerce(typeof(TValueType), fieldInfo.FieldType);

                var field = Expression.Field(null, fieldInfo);
                body = Expression.Assign(field, valueCast);
            }
            else
            {
                body = GetThrowMemberAccessExceptionExpression(fieldInfo, "write to");
            }

            var expression = Expression.Lambda<Action<TValueType>>(body, string.Format("<set>_{0}.{1}", fieldInfo.DeclaringType.Name, fieldInfo.Name), new[] { valueParameter });
            return expression;
        }

        private static MemberExpression GetField(FieldInfo fieldInfo, Type declaringType, ParameterExpression instanceParameter)
        {
            MemberExpression field;

            if (fieldInfo.IsStatic)
            {
                field = Expression.Field(null, fieldInfo);
            }
            else
            {
                var instanceCast = instanceParameter.Coerce(declaringType, fieldInfo.DeclaringType);
                field = Expression.Field(instanceCast, fieldInfo);
            }

            return field;
        }

        #endregion

        #region Property

        public static Expression<Func<object, object>> CreateGetValueFuncExpression(PropertyInfo propertyInfo)
        {
            return CreateGetValueFuncExpression<object, object>(propertyInfo);
        }

        public static Expression<Func<TInstanceType, TReturnType>> CreateGetValueFuncExpression<TInstanceType, TReturnType>(PropertyInfo propertyInfo)
        {
            var instanceParameter = Expression.Parameter(typeof(TInstanceType), "instance");

            Expression body;
            MethodInfo methodInfo;

            if (propertyInfo.CanRead && (methodInfo = propertyInfo.GetGetMethod(true)) != null)
            {
                MethodCallExpression call;

                if (propertyInfo.IsStatic())
                {
                    call = Expression.Call(methodInfo);
                }
                else
                {
                    var instanceCast = instanceParameter.Coerce(typeof(TInstanceType), methodInfo.DeclaringType);
                    call = Expression.Call(instanceCast, methodInfo);
                }

                body = call.Coerce(methodInfo.ReturnType, typeof(TReturnType));
            }
            else
            {
                body = Expression.Block(
                    typeof(TReturnType),
                    GetThrowMemberAccessExceptionExpression(propertyInfo, "read from"),
                    GetDefaultValueExpression(typeof(TReturnType)));
            }

            var expression = Expression.Lambda<Func<TInstanceType, TReturnType>>(body, string.Format("<get>_{0}.{1}", propertyInfo.DeclaringType.Name, propertyInfo.Name), new [] { instanceParameter });
            return expression;
        }

        public static Expression<Func<object>> CreateStaticGetValueFuncExpression(PropertyInfo propertyInfo)
        {
            return CreateStaticGetValueFuncExpression<object>(propertyInfo);
        }

        public static Expression<Func<TReturnType>> CreateStaticGetValueFuncExpression<TReturnType>(PropertyInfo propertyInfo)
        {
            Expression body;
            MethodInfo methodInfo;

            if (propertyInfo.CanRead && (methodInfo = propertyInfo.GetGetMethod(true)) != null)
            {
                var call = Expression.Call(methodInfo);
                body = call.Coerce(methodInfo.ReturnType, typeof(TReturnType));
            }
            else
            {
                body = GetThrowMemberAccessExceptionExpression(propertyInfo, "read from");
            }

            var expression = Expression.Lambda<Func<TReturnType>>(body, string.Format("<get>_{0}.{1}", propertyInfo.DeclaringType.Name, propertyInfo.Name), Enumerable.Empty<ParameterExpression>());
            return expression;
        }

        public static Expression<Action<object, object>> CreateSetValueFuncExpression(PropertyInfo propertyInfo)
        {
            return CreateSetValueFuncExpression<object, object>(propertyInfo);
        }

        public static Expression<Action<TInstanceType, TValueType>> CreateSetValueFuncExpression<TInstanceType, TValueType>(PropertyInfo propertyInfo)
        {
            var instanceParameter = Expression.Parameter(typeof(TInstanceType), "instance");
            var valueParameter = Expression.Parameter(typeof(TValueType), "value");

            Expression body;
            MethodInfo methodInfo;

            if (propertyInfo.CanWrite && (methodInfo = propertyInfo.GetSetMethod(true)) != null)
            {
                var valueCast = valueParameter.Coerce(typeof (TValueType),
                    methodInfo.GetParameters().Single().ParameterType);

                if (propertyInfo.IsStatic())
                {
                    body = Expression.Call(methodInfo, valueCast);
                }
                else
                {
                    var instanceCast = instanceParameter.Coerce(typeof (TInstanceType), methodInfo.DeclaringType);
                    // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                    body = Expression.Call(instanceCast, methodInfo, valueCast);
                }
            }
            else
            {
                body = GetThrowMemberAccessExceptionExpression(propertyInfo, "write to");
            }

            var expression = Expression.Lambda<Action<TInstanceType, TValueType>>(body, string.Format("<set>_{0}.{1}", propertyInfo.DeclaringType.Name, propertyInfo.Name), new[] { instanceParameter, valueParameter });
            return expression;
        }

        public static Expression<Action<object>> CreateStaticSetValueActionExpression(PropertyInfo propertyInfo)
        {
            return CreateStaticSetValueActionExpression<object>(propertyInfo);
        }

        public static Expression<Action<TValueType>> CreateStaticSetValueActionExpression<TValueType>(PropertyInfo propertyInfo)
        {
            var valueParameter = Expression.Parameter(typeof(TValueType), "value");

            Expression body;
            MethodInfo methodInfo;

            if (propertyInfo.CanWrite && (methodInfo = propertyInfo.GetSetMethod(true)) != null)
            {
                var valueCast = valueParameter.Coerce(typeof(TValueType), methodInfo.GetParameters().Single().ParameterType);

                body = Expression.Call(methodInfo, valueCast);
            }
            else
            {
                body = GetThrowMemberAccessExceptionExpression(propertyInfo, "write to");
            }
            
            var expression = Expression.Lambda<Action<TValueType>>(body, string.Format("<set>_{0}.{1}", propertyInfo.DeclaringType.Name, propertyInfo.Name), new[] { valueParameter });
            return expression;
        }

        private static Expression GetThrowMemberAccessExceptionExpression(MemberInfo memberInfo, string verb)
        {
            return Expression.Throw(
                Expression.New(
                    typeof(MemberAccessException).GetConstructor(new[] { typeof(string) }),
                    Expression.Constant(GetMemberAccessExceptionMessage(memberInfo, verb))));
        }

        private static string GetMemberAccessExceptionMessage(MemberInfo memberInfo, string verb)
        {
            var memberType = memberInfo is PropertyInfo ? "property" : "field";
            return string.Format("Cannot {0} {1}: {2}.{3}", verb, memberType, memberInfo.DeclaringType.FullName, memberInfo.Name);
        }

        #endregion

        #region Contructor

        public static Expression<Func<object[], object>> CreateConstructorFuncExpression(ConstructorInfo ctor)
        {
            if (ctor == null)
            {
                throw new ArgumentNullException("ctor");
            }

            var ctorParameters = ctor.GetParameters();

            var parameter = Expression.Parameter(typeof(object[]), "args");
            var coercedParameters =
                ctorParameters.Select(
                    (parameterInfo, i) =>
                        Expression.ArrayAccess(parameter, Expression.Constant(i)).Coerce(typeof(object), parameterInfo.ParameterType));

            var newExpression = Expression.New(ctor, coercedParameters);
            var newCast = newExpression.Coerce(ctor.DeclaringType, typeof(object));

            var expression = Expression.Lambda<Func<object[], object>>(newCast, string.Format("{0}.ctor", ctor.DeclaringType.Name), new[] { parameter });
            return expression;
        }

        #endregion

        #region Method

        public static Expression<Func<object, object[], object>> CreateNonGenericInstanceMethodFuncExpression(MethodInfo methodInfo)
        {
            var methodInfoParameters = methodInfo.GetParameters();

            var instanceParameter = Expression.Parameter(typeof(object), "instance");

            var parameter = Expression.Parameter(typeof(object[]), "args");
            var call = GetNonGenericCallExpression(methodInfo, instanceParameter, methodInfoParameters, parameter);

            var expression = Expression.Lambda<Func<object, object[], object>>(call, string.Format("{0}.{1}", methodInfo.DeclaringType.Name, methodInfo.Name), new [] { instanceParameter, parameter });
            return expression;
        }

        public static Expression<Action<object, object[]>> CreateNonGenericInstanceMethodActionExpression(MethodInfo methodInfo)
        {
            var methodInfoParameters = methodInfo.GetParameters();

            var instanceParameter = Expression.Parameter(typeof(object), "instance");

            var parameter = Expression.Parameter(typeof(object[]), "args");
            var call = GetNonGenericCallExpression(methodInfo, instanceParameter, methodInfoParameters, parameter);

            var expression = Expression.Lambda<Action<object, object[]>>(call, string.Format("{0}.{1}", methodInfo.DeclaringType.Name, methodInfo.Name), new[] { instanceParameter, parameter });
            return expression;
        }

        public static Expression<Func<object[], object>> CreateNonGenericStaticMethodFuncExpression(MethodInfo methodInfo)
        {
            if (!methodInfo.IsStatic)
            {
                throw new ArgumentException("Cannot create static method func on an instance MethodInfo", "methodInfo");
            }

            var methodInfoParameters = methodInfo.GetParameters();

            var parameter = Expression.Parameter(typeof(object[]), "args");
            var call = GetNonGenericCallExpression(methodInfo, null, methodInfoParameters, parameter);

            var expression = Expression.Lambda<Func<object[], object>>(call, string.Format("{0}.{1}", methodInfo.DeclaringType.Name, methodInfo.Name), new[] { parameter });
            return expression;
        }

        public static Expression<Action<object[]>> CreateNonGenericStaticMethodActionExpression(MethodInfo methodInfo)
        {
            if (!methodInfo.IsStatic)
            {
                throw new ArgumentException("Cannot create static method func on an instance MethodInfo", "methodInfo");
            }

            var methodInfoParameters = methodInfo.GetParameters();

            var parameter = Expression.Parameter(typeof(object[]), "args");
            var call = GetNonGenericCallExpression(methodInfo, null, methodInfoParameters, parameter);

            var expression = Expression.Lambda<Action<object[]>>(call, string.Format("{0}.{1}", methodInfo.DeclaringType.Name, methodInfo.Name), new[] { parameter });
            return expression;
        }

        #endregion

        private static Expression Coerce(this Expression sourceExpression, Type sourceType, Type targetType)
        {
            if (sourceType == typeof(void) && targetType != typeof(void))
            {
                var returnExpression = GetDefaultValueExpression(targetType);

                var block = Expression.Block(targetType, sourceExpression, returnExpression);
                return block;
            }

            if (!targetType.IsAssignableFrom(sourceType) || (targetType == typeof(object) && sourceType.IsValueType))
            {
                return Expression.Convert(sourceExpression, targetType);
            }

            return sourceExpression;
        }

        private static Expression GetCallExpression(
            MethodInfo methodInfo,
            ParameterExpression instanceParameter,
            Type instanceType,
            Type returnType,
            IEnumerable<ParameterInfo> parameterInfos,
            IEnumerable<Expression> parameterExpressions)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException("methodInfo");
            }

            returnType = returnType ?? typeof(void);
            parameterInfos = parameterInfos ?? Enumerable.Empty<ParameterInfo>();
            parameterExpressions = parameterExpressions ?? Enumerable.Empty<ParameterExpression>();

            var coercedParameters = parameterExpressions.Zip(
                parameterInfos,
                (parameterExpression, parameterInfo) =>
                    parameterExpression.Coerce(parameterExpression.Type, parameterInfo.ParameterType));

            MethodCallExpression call;

            if (methodInfo.IsStatic)
            {
                call = Expression.Call(methodInfo, coercedParameters);
            }
            else
            {
                if (instanceParameter == null)
                {
                    throw new ArgumentNullException("instanceParameter", "'instanceParameter' cannot be null when 'methodInfo' is not static.");
                }

                if (instanceType == null)
                {
                    throw new ArgumentNullException("instanceType", "'instanceType' cannot be null when 'methodInfo' is not static.");
                }

                var instanceCast = instanceParameter.Coerce(instanceType, methodInfo.DeclaringType);
                call = Expression.Call(instanceCast, methodInfo, coercedParameters);
            }

            var callCast = call.Coerce(methodInfo.ReturnType, returnType);
            return callCast;
        }

        private static Expression GetNonGenericCallExpression(
            MethodInfo methodInfo,
            ParameterExpression instanceParameter,
            IEnumerable<ParameterInfo> parameterInfos,
            ParameterExpression parameter)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException("methodInfo");
            }

            parameterInfos = parameterInfos ?? Enumerable.Empty<ParameterInfo>();

            var coercedParameters =
                parameterInfos.Select(
                    (parameterInfo, i) =>
                        Expression.ArrayAccess(parameter, Expression.Constant(i)).Coerce(typeof(object), parameterInfo.ParameterType));

            MethodCallExpression call;

            if (methodInfo.IsStatic)
            {
                call = Expression.Call(methodInfo, coercedParameters);
            }
            else
            {
                if (instanceParameter == null)
                {
                    throw new ArgumentNullException("instanceParameter", "'instanceParameter' cannot be null when 'methodInfo' is not static.");
                }

                var instanceCast = instanceParameter.Coerce(typeof(object), methodInfo.DeclaringType);
                call = Expression.Call(instanceCast, methodInfo, coercedParameters);
            }

            var callCast = call.Coerce(methodInfo.ReturnType, typeof(object));
            return callCast;
        }

        private static ParameterInfo[] GetMethodInfoParameters(MethodInfo methodInfo, params Type[] parameterTypes)
        {
            var methodInfoParameters = methodInfo.GetParameters();

            if (methodInfoParameters.Length != parameterTypes.Length)
            {
                throw new ArgumentException(string.Format("Wrong number of parameters. Should be {0}, but was {1}.", parameterTypes.Length, methodInfoParameters.Length), "methodInfo");
            }

            // TODO: make sure that methodInfoParameters is compatible with parameterTypes.

            return methodInfoParameters;
        }

        private static Expression GetDefaultValueExpression(Type targetType)
        {
            return targetType.IsValueType
                ? Expression.New(targetType)
                : Expression.Constant(null, targetType).Coerce(typeof(object), targetType);
        }
    }
}