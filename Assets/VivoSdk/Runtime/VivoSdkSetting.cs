using System.Collections.Generic;
using UnityEngine;
namespace VivoSdk
{
    public class VivoSdkSetting : AScriptableObject
    {
        public override string filePath => "Vivosdk/Setting";
        public string appid;
        public bool isDebug;
        public bool isLateInit;
    }
}
