package com.sdk.vivo;

import android.app.Application;

import com.api.unityactivityinterface.IOnAppCreate;
import com.vivo.unionsdk.open.VivoUnionSDK;

public class VivoSdkInitor implements IOnAppCreate
{
    String appid="1007";
    boolean isDebug= false;
    boolean isLateInit=false;
    @Override
    public void onCreate(Application activity) {
        if (!isLateInit)
            VivoUnionSDK.initSdk(activity, appid, isDebug);
    }
}
