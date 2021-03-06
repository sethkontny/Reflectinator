﻿////////////////////////////////////////////////////////////////////////////////
// This file was generated by a tool. Any manual changes to this file will be //
// lost if/when the file is regenerated. If changes need to be made to this   //
// file, they should be made in Constructor.tt, which regenerates this file.  //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Reflectinator
{
    public abstract class Constructor : Member, IConstructor
    {
        private static readonly ConcurrentDictionary<int, IConstructor> _constructorsMap = new ConcurrentDictionary<int, IConstructor>();

        private readonly ConstructorInfo _constructorInfo;
        private readonly Lazy<Expression<Func<object[], object>>> _invokeExpression;
        private readonly Lazy<Func<object[], object>> _invoke;
        private readonly Lazy<ITypeCrawler[]> _parameters;

        internal Constructor(ConstructorInfo constructorInfo)
            : base(constructorInfo)
        {
            if (constructorInfo == null)
            {
                throw new ArgumentNullException("constructorInfo");
            }

            _constructorInfo = constructorInfo;
            _invokeExpression = new Lazy<Expression<Func<object[], object>>>(() => ExpressionFactory.CreateConstructorFuncExpression(constructorInfo));
            _invoke = new Lazy<Func<object[], object>>(() => _invokeExpression.Value.Compile());
            _parameters = new Lazy<ITypeCrawler[]>(() => constructorInfo.GetParameters().Select(p => TypeCrawler.Get(p.ParameterType)).ToArray());
        }

#region Factory Methods

        public static IConstructor Get(ConstructorInfo constructorInfo)
        {
            var parameters = constructorInfo.GetParameters().Select(p => p.ParameterType).ToArray();

            return _constructorsMap.GetOrAdd(
                constructorInfo.DeclaringType.GetCacheKey(parameters),
                key =>
                {
                    Type constructorType;

                    switch (parameters.Length)
                    {
                        case 0:
                            constructorType = typeof(Constructor<>).MakeGenericType(constructorInfo.DeclaringType);
                            break;
                        case 1:
                            constructorType = typeof(Constructor<,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0]);
                            break;
                        case 2:
                            constructorType = typeof(Constructor<,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1]);
                            break;
                        case 3:
                            constructorType = typeof(Constructor<,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2]);
                            break;
                        case 4:
                            constructorType = typeof(Constructor<,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3]);
                            break;
                        case 5:
                            constructorType = typeof(Constructor<,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                            break;
                        case 6:
                            constructorType = typeof(Constructor<,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
                            break;
                        case 7:
                            constructorType = typeof(Constructor<,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6]);
                            break;
                        case 8:
                            constructorType = typeof(Constructor<,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7]);
                            break;
                        case 9:
                            constructorType = typeof(Constructor<,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8]);
                            break;
                        case 10:
                            constructorType = typeof(Constructor<,,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8], parameters[9]);
                            break;
                        case 11:
                            constructorType = typeof(Constructor<,,,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8], parameters[9], parameters[10]);
                            break;
                        case 12:
                            constructorType = typeof(Constructor<,,,,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11]);
                            break;
                        case 13:
                            constructorType = typeof(Constructor<,,,,,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11], parameters[12]);
                            break;
                        case 14:
                            constructorType = typeof(Constructor<,,,,,,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11], parameters[12], parameters[13]);
                            break;
                        case 15:
                            constructorType = typeof(Constructor<,,,,,,,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11], parameters[12], parameters[13], parameters[14]);
                            break;
                        case 16:
                            constructorType = typeof(Constructor<,,,,,,,,,,,,,,,,>).MakeGenericType(constructorInfo.DeclaringType, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7], parameters[8], parameters[9], parameters[10], parameters[11], parameters[12], parameters[13], parameters[14], parameters[15]);
                            break;
                        default:
                            throw new InvalidOperationException();
                    }

                    return (IConstructor)Activator.CreateInstance(constructorType, BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { constructorInfo }, null);
                });
        }

        public static Constructor<TDeclaringType> Get<TDeclaringType>()
        {
            return (Constructor<TDeclaringType>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(),
                key => new Constructor<TDeclaringType>());
        }

        public static Constructor<TDeclaringType, TArg1> Get<TDeclaringType, TArg1>()
        {
            return (Constructor<TDeclaringType, TArg1>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1)),
                key => new Constructor<TDeclaringType, TArg1>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2> Get<TDeclaringType, TArg1, TArg2>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2)),
                key => new Constructor<TDeclaringType, TArg1, TArg2>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3> Get<TDeclaringType, TArg1, TArg2, TArg3>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), typeof(TArg13)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), typeof(TArg13), typeof(TArg14)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), typeof(TArg13), typeof(TArg14), typeof(TArg15)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>());
        }

        public static Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16> Get<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>()
        {
            return (Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>)_constructorsMap.GetOrAdd(
                typeof(TDeclaringType).GetCacheKey(typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), typeof(TArg13), typeof(TArg14), typeof(TArg15), typeof(TArg16)),
                key => new Constructor<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>());
        }

#endregion

        public ConstructorInfo ConstructorInfo { get { return _constructorInfo; } }
        
        public override string Name { get { return "ctor"; } }
        public override bool IsPublic { get { return _constructorInfo.IsPublic; } }
        public override bool IsStatic { get { return false; } }

        public ITypeCrawler[] Parameters { get { return _parameters.Value; } }

        object IConstructor.Invoke(params object[] args) { return _invoke.Value(args); }
        Expression<Func<object[], object>> IConstructor.InvokeExpression { get { return _invokeExpression.Value; } }
        Func<object[], object> IConstructor.InvokeFunc { get { return _invoke.Value; } }
    }
}
