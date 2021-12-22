using System;
using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
namespace VivoSdk
{
    public class QuitDialog : IQuitDialog
    {
        
        class Proxy : AndroidJavaProxy
        {
            public Action<QuitButtonType> action;
            public Proxy() : base("com.vivo.unionsdk.open.VivoExitCallback")
            {
            }
            public void onExitCancel()
            {
                action?.Invoke(QuitButtonType.CANCEL);
            }

            public void onExitConfirm()
            {
                action?.Invoke(QuitButtonType.OK);
            }
        }
        Proxy proxy = new Proxy();

        public event Action onShow;
        public event Action<QuitButtonType> onClose;

        public void Show(Action<QuitButtonType> action)
        {
            proxy.action = action + onClose;
            if (PlatfotmHelper.isEditor())
            {
                action?.Invoke(QuitButtonType.OK);
            }
            else
            {
                Helper.sdk.CallStatic("exit", ActivityGeter.GetActivity(), proxy);
            }
            onShow?.Invoke();
        }
    }
}
