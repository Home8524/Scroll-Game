using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private int TileNum;
    private void Start()
    {
        TileNum = 1;
    }
    private void Update()
    {
        int Tmp = Singleton.GetInstance.TimeNum;
        if(TileNum!=Tmp)
        {
            TileNum++;
             if (TileNum == 23 || TileNum == 14||TileNum>32&&TileNum<45
                ||TileNum>48&&TileNum<61||TileNum > 102 && TileNum < 106
                || TileNum > 110 && TileNum < 114 || TileNum > 118 && TileNum < 122)
                transform.Translate(0.0f, -0.5f, 0.0f);
            else if (TileNum > 64 && TileNum < 91)
                transform.position += Vector3.right * 0.5f *
                -1.0f * Singleton.GetInstance.WayRoute;
            else
                transform.position += Vector3.right * 1.2f *
                -1.0f * Singleton.GetInstance.WayRoute;
        }
    }
}
