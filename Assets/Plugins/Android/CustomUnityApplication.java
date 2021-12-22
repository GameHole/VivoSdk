package com.api.unityactivityinterface;
import com.sdk.vivo.VivoSdkInitor;
import android.app.Application;
import java.util.ArrayList;
public class CustomUnityApplication extends Application{
     ArrayList<IOnAppCreate> _ionappcreate = new ArrayList<IOnAppCreate>();
     ArrayList<IOnAppTerminate> _ionappterminate = new ArrayList<IOnAppTerminate>();
     public CustomUnityApplication(){
          VivoSdkInitor _com_sdk_vivo_vivosdkinitor = new VivoSdkInitor();
          _ionappcreate.add(_com_sdk_vivo_vivosdkinitor);
     }
     @Override
     public void onCreate(){
          super.onCreate();
          for (IOnAppCreate item: _ionappcreate){
               item.onCreate(this);
          }
     }
     @Override
     public void onTerminate(){
          super.onTerminate();
          for (IOnAppTerminate item: _ionappterminate){
               item.onTerminate(this);
          }
     }
}
