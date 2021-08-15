using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using CommandLine;
using NLog;

namespace ET
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
			{
				Log.Error(e.ExceptionObject.ToString());
			};

			// 异步方法全部会回掉到主线程
			SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
			
			try
			{		
				//初始化EventSystem
				{
					List<Type> types = new List<Type>();
					types.AddRange( typeof(Game).Assembly.GetTypes());
					types.AddRange( DllHelper.GetHotfixAssembly().GetTypes());
					Game.EventSystem.AddRangeType(types);
					Game.EventSystem.TypeMonoInit();
					Game.EventSystem.EventSystemInit();
				}
				
				ProtobufHelper.Init();
				MongoHelper.Init();
				
				// 命令行参数
				Options options = null;
				Parser.Default.ParseArguments<Options>(args)
						.WithNotParsed(error => throw new Exception($"命令行格式错误!"))
						.WithParsed(o => { options = o; });

				GloabDefine.Options = options;

				GloabDefine.ILog = new NLogger(GloabDefine.Options.AppType.ToString());
				LogManager.Configuration.Variables["appIdFormat"] = $"{GloabDefine.Options.Process:000000}";
				
				Log.Info($"server start........................ {Game.Scene.Id}");

				Game.EventSystem.Publish(new EventType.AppStart());
				
				while (true)
				{
					try
					{
						Thread.Sleep(1);
						Game.Update();
						Game.LateUpdate();
						Game.FrameFinish();
					}
					catch (Exception e)
					{
						Log.Error(e);
					}
				}
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
		}
	}
}
