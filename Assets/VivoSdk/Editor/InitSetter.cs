using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
using UnityEditor;
namespace VivoSdk
{
    public class InitSetter : IParamSettng
    {
        public void SetParam()
        {
            SetJavaFile();
        }
        public static void SetJavaFile()
        {
            var set = AssetHelper.CreateOrGetAsset<VivoSdkSetting>();
            JavaHelper.RegistJavaInterfaceWithReplease(
                AssetDatabase.GUIDToAssetPath("3322098d99de2254dad85552b91edd03"),
                new KeyValuePair<string, string>("##APPID##", set.appid),
                new KeyValuePair<string, string>("##DEBUG##", set.isDebug.ToString().ToLower()),
                new KeyValuePair<string, string>("##LATE_INIT##", set.isLateInit.ToString().ToLower()));
            //JavaHelper.RegistJavaInterfaceWithReplease(AssetDatabase.GUIDToAssetPath("1c107e0275290aa42b566d227832051d"));
        }
    }
}
