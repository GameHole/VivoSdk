using System.Collections.Generic;
using UnityEngine;
namespace VivoSdk
{
	public static class Helper
	{
        public static readonly AndroidJavaClass sdk = new AndroidJavaClass("com.vivo.unionsdk.open.VivoUnionSDK");
	}
}
