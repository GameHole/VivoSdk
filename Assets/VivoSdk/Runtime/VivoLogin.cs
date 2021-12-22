using System;
using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
namespace VivoSdk
{
    public interface ILogin:IInterface
    {
    }
    public class VivoLogin : ILogin, IInitializable
    {
        class Proxy : AndroidJavaProxy
        {
            public Proxy() : base("com.vivo.unionsdk.open.VivoAccountCallback")
            {
            }
            public void onVivoAccountLogin(string username, string openid, string token)
            {
                Debug.Log($"onVivoAccountLogin username::{username}, openid::{openid},token::{token}");
            }

            public void onVivoAccountLogout(int code)
            {
                Debug.Log($"onVivoAccountLogout code {code}");
            }

            public void onVivoAccountLoginCancel()
            {
                Debug.Log("onVivoAccountLoginCancel");
            }
        }
        IVivoInitor initor;
        Proxy proxy = new Proxy();
        public void Init()
        {
            if (PlatfotmHelper.isEditor()) return;
            Helper.sdk.CallStatic("registerAccountCallback", ActivityGeter.GetActivity(), proxy);
            Helper.sdk.CallStatic("login", ActivityGeter.GetActivity());
        }

        public void Initialize()
        {
            var set = AScriptableObject.Get<VivoSdkSetting>();
            if (!set.isLateInit)
            {
                Init();
            }
            else
            {
                initor.onInited += Init;
            }
        }
    }
}
