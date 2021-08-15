using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class Debug_BindingCLR
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(UnityEngine.Debug);
            args = new Type[] { typeof(System.Object) };
            method = type.GetMethod("LogError", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, LogError_0);
            args = new Type[] { typeof(System.Object) };
            method = type.GetMethod("Log", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Log_1);
            args = new Type[] { typeof(System.Object) };
            method = type.GetMethod("LogWarning", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, LogWarning_2);
        }


        static StackObject* LogError_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            object message = StackObject.ToObject(ptr_of_this_method, __domain, __mStack);
            __intp.Free(ptr_of_this_method);
            string stackTrace = __domain.DebugService.GetStackTrace(__intp);
            UnityEngine.Debug.LogError(string.Format("{0}\n{1}\n{2}", message, stackTrace, "------热更LogError信息结束------"));
            return __ret;
        }

        static StackObject* Log_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            object message = StackObject.ToObject(ptr_of_this_method, __domain, __mStack);
            __intp.Free(ptr_of_this_method);
            string stackTrace = __domain.DebugService.GetStackTrace(__intp);
            UnityEngine.Debug.Log(string.Format("{0}\n{1}\n{2}", message, stackTrace, "------热更Log信息结束------"));
            return __ret;
        }

        static StackObject* LogWarning_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            object message = StackObject.ToObject(ptr_of_this_method, __domain, __mStack);
            __intp.Free(ptr_of_this_method);
            string stackTrace = __domain.DebugService.GetStackTrace(__intp);
            UnityEngine.Debug.LogWarning(string.Format("{0}\n{1}\n{2}", message, stackTrace, "------热更LogWarning信息结束------"));
            return __ret;

            return __ret;
        }
    }
}

