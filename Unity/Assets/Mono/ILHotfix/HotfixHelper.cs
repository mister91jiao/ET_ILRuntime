using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ILRuntime.CLR.TypeSystem;
using UnityEngine;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace ET
{
    public static class HotfixHelper
    {
        private static byte[] _dllByte;
        private static byte[] _pdbByte;
        
        private static IStaticMethod _entryMethod;
        
        private static AppDomain _appDomain;
        private static Assembly _assembly;

        /// <summary>
        /// 这里开始正式进入游戏逻辑
        /// </summary>
        public static void Go(byte[] dllByte, byte[] pdbByte)
        {
            _dllByte = dllByte;
            _pdbByte = pdbByte;

            if (GloabDefine.ILRuntimeMode)
            {
                _appDomain = ILHelper.InitILRuntimeAppdomain(_dllByte, _pdbByte);
                ILHelper.RegILRuntime(_appDomain);
                _entryMethod = ILHelper.MethodInit(_appDomain);
            }
            else
            {
                _assembly = ILHelper.InitAssembly(_dllByte, _pdbByte);
                _entryMethod = ILHelper.MethodInit(_assembly);
            }
            
            _entryMethod.Run();
            
        }

        public static Type[] GetAssemblyTypes()
        {
            Type[] types;
            if (GloabDefine.ILRuntimeMode)
            {
                
                types = _appDomain.LoadedTypes.Values.Select(t => t.ReflectionType).ToArray();
            }
            else
            {
                types = _assembly.GetTypes();
            }
            return types;
        }

        public static List<Type> GetIlrAttributeTypes(List<Type> types)
        {
            List<Type> attributeTypes = new List<Type>();
            foreach (Type item in types)
            {
                if (item.IsAbstract)
                {
                    continue;
                }
                
                if (item.IsSubclassOf(typeof(Attribute)))
                {
                    attributeTypes.Add(item);
                }
            }
            return attributeTypes;
        }
        
        
    }
}
