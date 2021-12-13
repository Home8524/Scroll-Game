using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameObject Canvas;
    GameObject Canvas2;
    private void Start()
    {
        Canvas = GameObject.Find("Text_Canvas");
        Canvas2 = GameObject.Find("UI");
    }
    public void Active()
    {
        Canvas.SetActive(true);
        Canvas2.SetActive(false);
        Time.timeScale = 1;
    }

}
