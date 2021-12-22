using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace VivoSdk
{
    [CustomEditor(typeof(VivoSdkSetting))]
	public class VivoSdkSettingEditor:Editor
	{
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            InitSetter.SetJavaFile();
        }
    }
}
