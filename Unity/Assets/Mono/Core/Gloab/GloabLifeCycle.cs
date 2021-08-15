using System;

namespace ET
{
    public static class GloabLifeCycle
    {
        public static Action StartAction;
		
        public static Action UpdateAction;
		
        public static Action LateUpdateAction;
		
        public static Action OnApplicationQuitAction;
    }
}
