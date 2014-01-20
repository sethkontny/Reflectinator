﻿////////////////////////////////////////////////////////////////////////////////
// This file was generated by a tool. Any manual changes to this file will be //
// lost if/when the file is regenerated. If changes need to be made to this   //
// file, they should be made in StaticActionMethod`n.tt, which regenerates    //
// this file.                                                                 //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Reflection;

namespace Reflectinator
{
    public sealed class StaticActionMethod<TDeclaringType> : ActionMethod<TDeclaringType>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action>(() => FuncFactory.CreateStaticMethodAction(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        public void Invoke() { _invoke.Value(); }
        public new Action InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1> : ActionMethod<TDeclaringType, TArg1>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1>>(() => FuncFactory.CreateStaticMethodAction<TArg1>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1) { _invoke.Value(arg1); }
        public new Action<TArg1> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2> : ActionMethod<TDeclaringType, TArg1, TArg2>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2) { _invoke.Value(arg1, arg2); }
        public new Action<TArg1, TArg2> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3) { _invoke.Value(arg1, arg2, arg3); }
        public new Action<TArg1, TArg2, TArg3> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) { _invoke.Value(arg1, arg2, arg3, arg4); }
        public new Action<TArg1, TArg2, TArg3, TArg4> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) { _invoke.Value(arg1, arg2, arg3, arg4, arg5); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14> InvokeDelegate { get { return _invoke.Value; } }
    }

    public sealed class StaticActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> : ActionMethod<TDeclaringType, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>, IStaticActionMethod
    {
        private readonly Lazy<Action<object[]>> _invokeLoose;
        private readonly Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>> _invoke;
        
        internal StaticActionMethod(MethodInfo methodInfo)
            : base(methodInfo)
        {
            _invokeLoose = new Lazy<Action<object[]>>(() => FuncFactory.CreateNonGenericStaticMethodAction(methodInfo));
            _invoke = new Lazy<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>>(() => FuncFactory.CreateStaticMethodAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(methodInfo));
        }
        
        public override bool IsStatic { get { return true; } }
        
        void IStaticActionMethod.Invoke(params object[] args) { _invokeLoose.Value(args); }
        Action<object[]> IStaticActionMethod.InvokeDelegate { get { return _invokeLoose.Value; } }

        object IStaticMethod.Invoke(params object[] args) { _invokeLoose.Value(args); return null; }
        Func<object[], object> IStaticMethod.InvokeDelegate { get { return ((IStaticMethod)this).Invoke; } }
        
        public void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10, TArg11 arg11, TArg12 arg12, TArg13 arg13, TArg14 arg14, TArg15 arg15) { _invoke.Value(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15); }
        public new Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> InvokeDelegate { get { return _invoke.Value; } }
    }

}