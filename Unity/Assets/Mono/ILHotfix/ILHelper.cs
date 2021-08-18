using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using ILRuntime.Runtime;
using ILRuntime.Runtime.Generated;
using ILRuntime.Runtime.Intepreter;
using UnityEngine;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace ET
{
    public static class ILHelper
    {
        /// <summary>
        /// 初始化ILRuntime的appdomain
        /// </summary>
        public static AppDomain InitILRuntimeAppdomain(byte[] dllByte, byte[] pdbByte)
        {
            AppDomain appdomain = new AppDomain(ILRuntimeJITFlags.NoJIT);
            appdomain.LoadAssembly(new MemoryStream(dllByte), new MemoryStream(pdbByte),
                new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());
            
            return appdomain;
        }
        
        /// <summary>
        /// ILRuntime下的所有注册
        /// </summary>
        public static void RegILRuntime(AppDomain appdomain)
        {
            // 注册委托
            RegDelegate(appdomain);

            MyClrBinding(appdomain);
            
            //注册Json的CLR
            LitJson.JsonMapper.RegisterILRuntimeCLRRedirection(appdomain);
            //注册ProtoBuf的CLR
            ProtoBuf.PBType.RegisterILRuntimeCLRRedirection(appdomain);
            
            CLRBindings.Initialize(appdomain);

            RegAdaptor(appdomain);
            
            //开启调试
            //appdomain.DebugService.StartDebugService(56000);
            
        }
        
        /// <summary>
        /// 创建进入入口
        /// </summary>
        public static ILStaticMethod MethodInit(AppDomain appdomain)
        {
            ILStaticMethod entryMethod = new ILStaticMethod(appdomain, "ET.InitEntry", "RegFunction", 0);
            return entryMethod;
        }
        
        /// <summary>
        /// 初始化ILRuntime的appdomain
        /// </summary>
        public static Assembly InitAssembly(byte[] dllByte, byte[] pdbByte)
        {
            Assembly assembly = Assembly.Load(dllByte, pdbByte);
            return assembly;
        }
        
        /// <summary>
        /// 创建进入入口
        /// </summary>
        public static MonoStaticMethod MethodInit(Assembly assembly)
        {
            MonoStaticMethod entryMethod = new MonoStaticMethod(assembly, "ET.InitEntry", "RegFunction");
            return entryMethod;
        }
        
        /// <summary>
        /// 自己的CLR绑定脚本初始化
        /// </summary>
        private static void MyClrBinding(AppDomain appdomain)
        {
            Debug_BindingCLR.Register(appdomain);
            ETLog_BindingCLR.Register(appdomain);
        }
        
        
        /// <summary>
        /// 注册所有适配器
        /// </summary>
        public static void RegAdaptor(AppDomain appdomain)
        {
            //注册自己写的适配器
            appdomain.RegisterCrossBindingAdaptor(new MonoBehaviourAdapter());
            appdomain.RegisterCrossBindingAdaptor(new IAsyncStateMachineClassInheritanceAdaptor());
            
            //注册自动生成的适配器
            //appdomain.RegisterCrossBindingAdaptor(new IDisposableAdapter());
            appdomain.RegisterCrossBindingAdaptor(new ISupportInitializeAdapter());
            
        }

        /// <summary>
        /// 注册所有委托
        /// </summary>
        private static void RegDelegate(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterMethodDelegate<List<object>>();
            appdomain.DelegateManager.RegisterMethodDelegate<object>();
            appdomain.DelegateManager.RegisterMethodDelegate<bool>();
            appdomain.DelegateManager.RegisterMethodDelegate<string>();
            appdomain.DelegateManager.RegisterMethodDelegate<float>();
            appdomain.DelegateManager.RegisterMethodDelegate<long, int>();
            appdomain.DelegateManager.RegisterMethodDelegate<long, MemoryStream>();
            appdomain.DelegateManager.RegisterMethodDelegate<long, IPEndPoint>();
			
            
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Events.UnityAction>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, ET.ETTask>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ILTypeInstance, bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.Int32, System.Int32>, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Collections.Generic.KeyValuePair<System.String, System.Int32>, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<List<int>, int>();
            appdomain.DelegateManager.RegisterFunctionDelegate<List<int>, bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<int, bool>();//Linq
            appdomain.DelegateManager.RegisterFunctionDelegate<int, int, int>();//Linq
            appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<int, List<int>>, bool>();
            appdomain.DelegateManager.RegisterFunctionDelegate<KeyValuePair<int, int>, KeyValuePair<int, int>, int>();
            
            
            
            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
            {
                return new UnityEngine.Events.UnityAction(() =>
                {
                    ((Action)act)();
                });
            });
            appdomain.DelegateManager.RegisterDelegateConvertor<Comparison<KeyValuePair<int, int>>>((act) =>
            {
                return new Comparison<KeyValuePair<int, int>>((x, y) =>
                {
                    return ((Func<KeyValuePair<int, int>, KeyValuePair<int, int>, int>)act)(x, y);
                });
            });
            
            
        }
    }
}
