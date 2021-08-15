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
    unsafe class ET_GloabLifeCycle_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ET.GloabLifeCycle);

            field = type.GetField("StartAction", flag);
            app.RegisterCLRFieldGetter(field, get_StartAction_0);
            app.RegisterCLRFieldSetter(field, set_StartAction_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_StartAction_0, AssignFromStack_StartAction_0);
            field = type.GetField("UpdateAction", flag);
            app.RegisterCLRFieldGetter(field, get_UpdateAction_1);
            app.RegisterCLRFieldSetter(field, set_UpdateAction_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_UpdateAction_1, AssignFromStack_UpdateAction_1);
            field = type.GetField("LateUpdateAction", flag);
            app.RegisterCLRFieldGetter(field, get_LateUpdateAction_2);
            app.RegisterCLRFieldSetter(field, set_LateUpdateAction_2);
            app.RegisterCLRFieldBinding(field, CopyToStack_LateUpdateAction_2, AssignFromStack_LateUpdateAction_2);
            field = type.GetField("OnApplicationQuitAction", flag);
            app.RegisterCLRFieldGetter(field, get_OnApplicationQuitAction_3);
            app.RegisterCLRFieldSetter(field, set_OnApplicationQuitAction_3);
            app.RegisterCLRFieldBinding(field, CopyToStack_OnApplicationQuitAction_3, AssignFromStack_OnApplicationQuitAction_3);


        }



        static object get_StartAction_0(ref object o)
        {
            return ET.GloabLifeCycle.StartAction;
        }

        static StackObject* CopyToStack_StartAction_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GloabLifeCycle.StartAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_StartAction_0(ref object o, object v)
        {
            ET.GloabLifeCycle.StartAction = (System.Action)v;
        }

        static StackObject* AssignFromStack_StartAction_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @StartAction = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ET.GloabLifeCycle.StartAction = @StartAction;
            return ptr_of_this_method;
        }

        static object get_UpdateAction_1(ref object o)
        {
            return ET.GloabLifeCycle.UpdateAction;
        }

        static StackObject* CopyToStack_UpdateAction_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GloabLifeCycle.UpdateAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_UpdateAction_1(ref object o, object v)
        {
            ET.GloabLifeCycle.UpdateAction = (System.Action)v;
        }

        static StackObject* AssignFromStack_UpdateAction_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @UpdateAction = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ET.GloabLifeCycle.UpdateAction = @UpdateAction;
            return ptr_of_this_method;
        }

        static object get_LateUpdateAction_2(ref object o)
        {
            return ET.GloabLifeCycle.LateUpdateAction;
        }

        static StackObject* CopyToStack_LateUpdateAction_2(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GloabLifeCycle.LateUpdateAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_LateUpdateAction_2(ref object o, object v)
        {
            ET.GloabLifeCycle.LateUpdateAction = (System.Action)v;
        }

        static StackObject* AssignFromStack_LateUpdateAction_2(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @LateUpdateAction = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ET.GloabLifeCycle.LateUpdateAction = @LateUpdateAction;
            return ptr_of_this_method;
        }

        static object get_OnApplicationQuitAction_3(ref object o)
        {
            return ET.GloabLifeCycle.OnApplicationQuitAction;
        }

        static StackObject* CopyToStack_OnApplicationQuitAction_3(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ET.GloabLifeCycle.OnApplicationQuitAction;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_OnApplicationQuitAction_3(ref object o, object v)
        {
            ET.GloabLifeCycle.OnApplicationQuitAction = (System.Action)v;
        }

        static StackObject* AssignFromStack_OnApplicationQuitAction_3(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Action @OnApplicationQuitAction = (System.Action)typeof(System.Action).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            ET.GloabLifeCycle.OnApplicationQuitAction = @OnApplicationQuitAction;
            return ptr_of_this_method;
        }



    }
}
