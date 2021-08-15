using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.AccessControl;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using AssemblyBuilder = UnityEditor.Compilation.AssemblyBuilder;

namespace ET
{
    public class ServerCommandLineEditor: EditorWindow
    {
        [MenuItem("Tools/打开服务器选项")]
        private static void ShowWindow()
        {
            GetWindow(typeof(ServerCommandLineEditor));
        }
        
        public void OnGUI()
        {
            if (GUILayout.Button("启动守护进程"))
            {
                string arguments = $"--AppType=Watcher --Process=1 --Console=1";
                ProcessHelper.Run("Server.exe", arguments, "../Bin/");
            }
            
            if (GUILayout.Button("启动机器人"))
            {
                string arguments = $"--AppType=Robot --Console=1";
                ProcessHelper.Run("Robot.exe", arguments, "../Bin/");
            }
            
            if (GUILayout.Button("启动服务器"))
            {
                string arguments = $"--AppType=Server --Console=1";
                ProcessHelper.Run("Server.exe", arguments, "../Bin/");
            }
            
            if (GUILayout.Button("构建DLL"))
            {
                BuildAssemblieEditor.BuildMuteAssembly("CodeFull", new []
                {
                    "Assets/Model/",
                    "Assets/ModelView/",
                    "Assets/Hotfix/",
                    "Assets/HotfixView/"
                });
                AssetDatabase.Refresh();
            }
            
            if (GUILayout.Button("刷新资源"))
            {
                AssetDatabase.Refresh();
            }
        }
    }
}