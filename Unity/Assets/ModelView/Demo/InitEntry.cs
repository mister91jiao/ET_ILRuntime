using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
	public static class InitEntry
	{
		public static void RegFunction()
		{
			GloabLifeCycle.StartAction += Start;
			GloabLifeCycle.UpdateAction += Update;
			GloabLifeCycle.LateUpdateAction += LateUpdate;
			GloabLifeCycle.OnApplicationQuitAction += OnApplicationQuit;
		}
		
		private static void Start()
		{
			try
			{
				//初始化EventSystem
				{
					List<Type> types = new List<Type>();
					types.AddRange( HotfixHelper.GetAssemblyTypes());
					Game.EventSystem.AddRangeType(types);
					if (GloabDefine.ILRuntimeMode)
					{
						Game.EventSystem.TypeIlrInit();
					}
					else
					{
						Game.EventSystem.TypeMonoInit();
					}
					Game.EventSystem.EventSystemInit();
				}
				
				ProtobufHelper.Init();
				GloabDefine.Options = new Options();
				
				Game.EventSystem.Publish(new EventType.AppStart()).Coroutine();
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
		}
		
		

		private static void Update()
		{
			Game.EventSystem.Update();
		}

		private static void LateUpdate()
		{
			Game.EventSystem.LateUpdate();
		}

		private static void OnApplicationQuit()
		{
			Game.Close();
		}
	}
}