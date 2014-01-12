﻿using System;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Reflectinator
{
    public class CachedConstructorInfo : DynamicObject, ICachedConstructorInfo
    {
        private readonly ConstructorInfo _constructorInfo;
        private readonly Lazy<Func<object[], object>> _invoke;
        private readonly Lazy<ICachedType> _declaringType;
        private readonly Lazy<ICachedType[]> _parameters;

        protected CachedConstructorInfo(ConstructorInfo constructorInfo)
        {
            if (constructorInfo == null)
            {
                throw new ArgumentNullException("constructorInfo");
            }

            _constructorInfo = constructorInfo;
            _invoke = new Lazy<Func<object[], object>>(() => (Func<object[], object>)FuncFactory.CreateConstructorFunc(constructorInfo, false));
            _declaringType = new Lazy<ICachedType>(() => CachedType.Create(constructorInfo.DeclaringType));
            _parameters = new Lazy<ICachedType[]>(() => constructorInfo.GetParameters().Select(p => CachedType.Create(p.ParameterType)).ToArray());
        }

        public static ICachedConstructorInfo Create(ConstructorInfo constructorInfo)
        {
            return new CachedConstructorInfo(constructorInfo);
        }

        public static CachedConstructorInfo<TDeclaringType> Create<TDeclaringType>()
        {
            return new CachedConstructorInfo<TDeclaringType>();
        }

        public static CachedConstructorInfo<TDeclaringType, TArg1> Create<TDeclaringType, TArg1>()
        {
            return new CachedConstructorInfo<TDeclaringType, TArg1>();
        }

        public static CachedConstructorInfo<TDeclaringType, TArg1, TArg2> Create<TDeclaringType, TArg1, TArg2>()
        {
            return new CachedConstructorInfo<TDeclaringType, TArg1, TArg2>();
        }

        public ConstructorInfo ConstructorInfo { get { return _constructorInfo; } }
        public bool IsPublic { get { return _constructorInfo.IsPublic; } }
        public ICachedType DeclaringType { get { return _declaringType.Value; } }
        public ICachedType[] Parameters { get { return _parameters.Value; } }

        public object Invoke(params object[] args)
        {
            return _invoke.Value(args);
        }
    }
}