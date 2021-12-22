using MiniGameSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoSdk;
public class TestQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("aaa");
            Refinter.Reflection.Get<IQuitDialog>().Show((type) =>
            {
                Debug.Log(type);
            });
        }
    }
}
