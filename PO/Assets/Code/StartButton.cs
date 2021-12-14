using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
   
    public void Active()
    {
        Singleton.GetInstance.Canvas1.SetActive(false);
        Singleton.GetInstance.Canvas3.SetActive(false);
        Singleton.GetInstance.Canvas2.SetActive(true);
        Time.timeScale = 1;
    }

}
