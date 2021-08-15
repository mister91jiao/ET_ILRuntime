using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class ConfigLoader: IConfigLoader
    {
        public void GetAllConfigBytes(Dictionary<string, byte[]> output)
        {
            var types = Game.EventSystem.GetTypes(typeof(ConfigAttribute));

            foreach (var kv in types)
            {
                
                string path = @"Config/Config/" + kv.Name;

                
                output[kv.Name] = Resources.Load<TextAsset>(path).bytes;
            }
        }

        public byte[] GetOneConfigBytes(string configName)
        {
            string path = @"Config/Config/" + configName;

            var v = Resources.Load<TextAsset>(path);
            return v.bytes;
        }
    }
}