using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSingletonTest : MonoBehaviour
{

    private void Awake()
    {
        //Signleton 3
        Singleton.Getinstance();
    }
   // void Update()
   // {
   //     if(Input.GetKeyDown(KeyCode.Return))
   //     {
   //         //Signleton 1
   //         //Singleton.Getinstance().Output();
   //
   //         //Singleton 2
   //         Singleton.Getinstance.Output();
   //     }
   // }
}
