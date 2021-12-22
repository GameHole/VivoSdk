using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
using System;

namespace VivoSdk
{
    public interface IVivoInitor : IInterface
    {
        event Action onInited;
    }
    public class VivoInitor : IVivoInitor, IMenualInitor
    {
        public event Action onInited;

        public void Init()
        {
            var set = AScriptableObject.Get<VivoSdkSetting>();
            using (AndroidJavaClass jo = new AndroidJavaClass("com.vivo.unionsdk.open.VivoUnionSDK"))
            {
                jo.CallStatic("initSdk", ActivityGeter.GetActivity(), set.appid, set.isDebug);
            }
            onInited?.Invoke();
        }
    }
}
