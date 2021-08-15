using UnityEditor;
using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ET
{
    [System.Reflection.Obfuscation(Exclude = true)]
    public class ILRuntimeCLRBinding
    {
        [MenuItem("Tools/ILRuntime/通过自动分析热更DLL生成CLR绑定")]
        static void GenerateCLRBindingByAnalysis()
        {
            //用新的分析热更dll调用引用来生成绑定代码
            ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
            using (System.IO.FileStream fs = new System.IO.FileStream(BuildAssemblieEditor.ScriptAssembliesDir + "CodeFull.dll", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                domain.LoadAssembly(fs);

                ILHelper.RegAdaptor(domain);

                ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, "Assets/Mono/ILRuntimeGenerate/ILBindingAuto");
            }

            AssetDatabase.Refresh();

            Debug.Log("生成CLR绑定文件完成");
        }
    }
}