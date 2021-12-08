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
            transform.position += Vector3.right * 1.2f;
        }
    }
}
