using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private int TileNum;
    GameObject BackGround;
    private void Start()
    {
        BackGround = GameObject.Find("BackGround");
        TileNum = 1;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BackGround.transform.localScale = new Vector3(3.0f,3.0f,1.0f)*1.03f;
            Invoke("Reset", 0.1f);
        }

        int Tmp = Singleton.GetInstance.TimeNum;
        if(TileNum!=Tmp)
        {
            TileNum++;
             if (TileNum == 23 || TileNum == 14||TileNum>32&&TileNum<45
                ||TileNum>48&&TileNum<61||TileNum > 102 && TileNum < 106
                || TileNum > 110 && TileNum < 114 || TileNum > 118 && TileNum < 122
                || TileNum > 126 && TileNum < 130)
                transform.Translate(0.0f, -0.5f, 0.0f);
            else if (TileNum > 64 && TileNum < 91)
                transform.position += Vector3.right * 0.5f *
                -1.0f * Singleton.GetInstance.WayRoute;
            else if (TileNum > 130 && TileNum < 161)
            {
                int TileCheck = (TileNum - 130) % 8;
                if (TileCheck == 7)
                    transform.Translate(0.0f, -0.5f, 0.0f);
                else
                    transform.Translate(0.4f * Singleton.GetInstance.WayRoute * -0.9f, 0.0f, 0.0f);
            }
            else
                transform.position += Vector3.right * 1.2f *
                -1.0f * Singleton.GetInstance.WayRoute;
        }
    }
    private void Reset()
    {
        BackGround.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f) * 1.0f;
    }
}
