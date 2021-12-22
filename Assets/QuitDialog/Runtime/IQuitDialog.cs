using System;
using System.Collections.Generic;
using UnityEngine;
namespace MiniGameSDK
{
    public enum QuitButtonType
    {
        OK,CANCEL
    }
	public interface IQuitDialog:IInterface
	{
        void Show(Action<QuitButtonType> onClose);
        event Action onShow;
        event Action<QuitButtonType> onClose;
    }
}
