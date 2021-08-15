using System;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

namespace ET
{
	public class Init: MonoBehaviour
	{
		public bool ILRuntimeMode = false;
		
		private void Awake()
		{
			GloabDefine.ILRuntimeMode = this.ILRuntimeMode;
			
			SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
			
			DontDestroyOnLoad(gameObject);

			byte[] dllByte = Resources.Load<GameObject>("Code/Code").GetComponent<ReferenceCollector>().Get<TextAsset>("CodeFull.dll").bytes;
			byte[] pdbByte = Resources.Load<GameObject>("Code/Code").GetComponent<ReferenceCollector>().Get<TextAsset>("CodeFull.pdb").bytes;
			
			HotfixHelper.Go(dllByte, pdbByte);
		}

		private void Start()
		{
			GloabLifeCycle.StartAction?.Invoke();
		}

		private void Update()
		{
			ThreadSynchronizationContext.Instance.Update();
			GloabLifeCycle.UpdateAction?.Invoke();
		}

		private void LateUpdate()
		{
			GloabLifeCycle.LateUpdateAction?.Invoke();
		}

		private void OnApplicationQuit()
		{
			GloabLifeCycle.OnApplicationQuitAction?.Invoke();
		}
	}
}