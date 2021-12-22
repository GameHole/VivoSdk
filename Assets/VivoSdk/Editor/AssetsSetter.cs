using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
using UnityEditor;

namespace VivoSdk
{
    public class AssetsSetter : IParamSettng
    {
        public void SetParam()
        {
            AssetHelper.CreateOrGetAsset<VivoSdkSetting>();
            AssetDatabase.Refresh();
        }
    }
}
