using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
using UnityEditor;

namespace VivoSdk
{
    public class XmlSetter : IParamSettng
    {
        public void SetParam()
        {
            var doc = XmlHelper.GetAndroidManifest();
            doc.SetPermissions("vivo.game.permission.OPEN_JUMP_INTENTS",
                "android.permission.CHANGE_NETWORK_STATE",
                "android.permission.ACCESS_WIFI_STATE",
                "android.permission.INTERNET",
                "android.permission.ACCESS_NETWORK_STATE",
                "android.permission.READ_PHONE_STATE",
                "android.permission.WRITE_EXTERNAL_STORAGE",
                "android.permission.READ_EXTERNAL_STORAGE",
                "android.permission.GET_TASKS",
                "android.permission.REQUEST_INSTALL_PACKAGES");
            var app = doc.SelectSingleNode("/manifest/application");
            var act= app.FindNode("activity", "android:name", "com.vivo.unionsdk.ui.UnionActivity");
            if (act == null)
            {
                act = doc.CreateElement("activity");
                act.CreateAttribute("name", "com.vivo.unionsdk.ui.UnionActivity");
                act.CreateAttribute("configChanges", "orientation|keyboardHidden|navigation|screenSize");
                act.CreateAttribute("exported", "false");
                act.CreateAttribute("theme", "@android:style/Theme.Dialog");
                act.CreateAttribute("ignore", "AppLinkUrlError", "tools");
                act.CreateAttribute("name", "com.vivo.unionsdk.ui.UnionActivity");
                var intent = doc.CreateElement("intent-filter");
                var action= doc.CreateElement("action");
                action.CreateAttribute("name", "android.intent.action.VIEW");
                intent.AppendChild(action);
                var category = doc.CreateElement("category");
                category.CreateAttribute("name", "android.intent.category.DEFAULT");
                intent.AppendChild(category);
                category = doc.CreateElement("category");
                category.CreateAttribute("name", "android.intent.category.BROWSABLE");
                intent.AppendChild(category);
                var data = doc.CreateElement("data");
                data.CreateAttribute("host", "union.vivo.com");
                data.CreateAttribute("path", "/openjump");
                data.CreateAttribute("scheme", "vivounion");
                intent.AppendChild(data);
                act.AppendChild(intent);
                app.AppendChild(act);

                var meta = doc.CreateElement("meta-data");
                meta.AppendAttribute("name", "vivo_union_sdk");
                meta.AppendAttribute("value", "4.6.7.0");
                app.AppendChild(meta);
            }
            doc.Save();
            AssetDatabase.Refresh();
        }
    }
}
