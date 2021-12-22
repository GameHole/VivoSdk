using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Android;
using System.IO;
using System;

namespace VivoSdk
{
    public class VivoAdkPostProcessing : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder => 999;

        class CopyFile
        {
            public static readonly Action<string, string> defaultAction=(srcPath,targetPath)=> 
            {
                File.Delete(targetPath);
                File.Copy(srcPath, targetPath);
            };
            public string guid;
            public string targetFloader;
            public string fileName;
            public Action<string, string> copyAction = defaultAction;
            public CopyFile(string guid,string target)
            {
                this.guid = guid;
                this.targetFloader = target;
            }
            public CopyFile(string guid, string target,string fileName):this(guid, target)
            {
                this.fileName = fileName;
            }
        }
        static CopyFile[] copies = new CopyFile[]
        {
            new CopyFile("ee63be425037cde40afdebfd483638c0","src/main/assets/vivounionsdk"),
            new CopyFile("8fa80350c9ba0dc4e97b28056bb6861e","src/main/assets")
            {
                copyAction = (srcPath,targetPath)=>
                {
                    var set=AssetHelper.CreateOrGetAsset<VivoSdkSetting>();
                    string file = File.ReadAllText(srcPath);
                    file = file.Replace("##APPID##",set.appid);
                    File.WriteAllText(targetPath,file);
                }
            }
            //new CopyFile("71aacb1410d50204d95e44276059647a","src/main/jniLibs/armeabi-v7a","libvivo_account_sdk.so"),
        };
        public void OnPostGenerateGradleAndroidProject(string path)
        {
            foreach (var item in copies)
            {
                string orgion = AssetDatabase.GUIDToAssetPath(item.guid);
                string targetFloader = Path.Combine(path, item.targetFloader);
                if (!Directory.Exists(targetFloader))
                {
                    Directory.CreateDirectory(targetFloader);
                }
                string fileName = item.fileName;
                if (string.IsNullOrEmpty(fileName))
                    fileName = Path.GetFileName(orgion);
                string targetPath = Path.Combine(targetFloader, fileName);
                item.copyAction.Invoke(orgion, targetPath);
            }
        }
    }
}

