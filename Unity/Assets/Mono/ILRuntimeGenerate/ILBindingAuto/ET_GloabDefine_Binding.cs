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
    unsafe class ET_GloabDefine_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ET.GloabDefine);

            field = type.GetField("Options", flag);
            app.RegisterCLRFieldGetter(field, get_Options_0);
            app.RegisterCLRFieldSetter(field, set_Options_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Options_0, AssignFromStack_Options_0);
            field = type.GetField("ILog", flag);
            app.RegisterCLRFieldGetter(field, get_ILog_1);
            app.RegisterCLRFieldSetter(field, set_ILog_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_ILog_1, AssignFromStack_ILog_1);
            field = type.GetField("ILRuntimeMode", flag);
            app.RegisterCLRFieldGetter(field, get_ILRuntimeMode_2);
            app.RegisterCLRFieldSetter(field, set_ILRuntimeMode_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_ILRuntimeMode_2, AssignFromStack_ILRuntimeMode_2);


        }



        static object get_Options_0(ref object o)
        {
            return ET.GloabDefine.Options;
        }

        static StackObject* CopyToStack_Options_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GloabDefine.Options;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Options_0(ref object o, object v)
        {
            ET.GloabDefine.Options = (ET.Options)v;
        }

        static StackObject* AssignFromStack_Options_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            ET.Options @Options = (ET.Options)typeof(ET.Options).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ET.GloabDefine.Options = @Options;
            return ptr_of_this_method;
        }

        static object get_ILog_1(ref object o)
        {
            return ET.GloabDefine.ILog;
        }

        static StackObject* CopyToStack_ILog_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GloabDefine.ILog;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_ILog_1(ref object o, object v)
        {
            ET.GloabDefine.ILog = (ET.ILog)v;
        }

        static StackObject* AssignFromStack_ILog_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            ET.ILog @ILog = (ET.ILog)typeof(ET.ILog).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            ET.GloabDefine.ILog = @ILog;
            return ptr_of_this_method;
        }

        static object get_ILRuntimeMode_2(ref object o)
        {
            return ET.GloabDefine.ILRuntimeMode;
        }

        static StackObject* CopyToStack_ILRuntimeMode_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GloabDefine.ILRuntimeMode;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_ILRuntimeMode_2(ref object o, object v)
        {
            ET.GloabDefine.ILRuntimeMode = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_ILRuntimeMode_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @ILRuntimeMode = ptr_of_this_method->Value == 1;
            ET.GloabDefine.ILRuntimeMode = @ILRuntimeMode;
            return ptr_of_this_method;
        }



    }
}
