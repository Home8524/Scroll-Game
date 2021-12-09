using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    [SerializeField] private GameObject TilePrefab1;
    [SerializeField] private GameObject TilePrefab2;
    private int Swap;
    private void Awake()
    {
        TilePrefab1 = Resources.Load("Prefabs/b1") as GameObject;
        TilePrefab2 = Resources.Load("Prefabs/RotateTile") as GameObject;
    }
    void Start()
    {
        //Time Create
        //윗줄 12개
        for(int i=0; i<12; ++i)
        {
            GameObject Tmp = GameObject.Find("Tile");

            GameObject Obj = Instantiate(TilePrefab1);
            Obj.transform.name = "Tile "+ i;
            Obj.transform.parent = Tmp.transform;
            
            Vector2 Pos =new Vector2();
            Pos.y = Obj.transform.position.y;
            Pos.x = Obj.transform.position.x + 1.2f * i;
            Obj.transform.position = Pos;

            if(i!=0)
            {
                Obj.AddComponent<BoxCollider2D>();
                BoxCollider2D Box = Obj.GetComponent<BoxCollider2D>();
                Vector2 Size = new Vector2(1.5f, 2.0f);
                Box.size = Size;
                Box.isTrigger = true;

            }    
        }
        //방향 전환용 2개
        for(int i=12; i<14; ++i)
        {
            GameObject Tmp = GameObject.Find("Tile");

            GameObject Obj = Instantiate(TilePrefab2);
            Obj.transform.name = "Tile " + i;
            Obj.transform.parent = Tmp.transform;

            Vector2 Pos = new Vector2(21.3f,5.715f);
            Pos.y = Pos.y - (i - 12);
            Pos.x = Pos.x + ((i - 12) * 0.02f);
            if(i==12)
                Obj.transform.Rotate(0.0f, 0.0f, -90.0f);
            else
                Obj.transform.Rotate(0.0f, 0.0f, -180.0f);
            Obj.transform.position = Pos;

            Obj.AddComponent<BoxCollider2D>();
            BoxCollider2D Box = Obj.GetComponent<BoxCollider2D>();
            Vector2 Size = new Vector2(1.5f, 2.0f);
            Box.size = Size;
            Box.isTrigger = true;
        }
        //두번재 줄 7개
        for(int i =14; i<21; ++i)
        {
            GameObject Tmp = GameObject.Find("Tile");

            GameObject Obj = Instantiate(TilePrefab1);
            Obj.transform.name = "Tile " + i;
            Obj.transform.parent = Tmp.transform;

            Vector2 Pos = new Vector2(20.2f,4.72f);
            Pos.x = Pos.x - 1.2f * (i - 14);
            Obj.transform.position = Pos;
            Obj.AddComponent<BoxCollider2D>();
            BoxCollider2D Box = Obj.GetComponent<BoxCollider2D>();
            Vector2 Size = new Vector2(1.5f, 2.0f);
            Box.size = Size;
            Box.isTrigger = true;

        }
        //방향 전환용 2개
        for(int i=21; i<23; ++i)
        {
            GameObject Tmp = GameObject.Find("Tile");

            GameObject Obj = Instantiate(TilePrefab2);
            Obj.transform.name = "Tile " + i;
            Obj.transform.parent = Tmp.transform;

            Vector2 Pos = new Vector2(11.92f, 4.72f);
            Pos.y -= (i - 21);
            Obj.transform.position = Pos;
            if (i == 22)
                Obj.transform.Rotate(0.0f, 0.0f, 90.0f);
            Obj.AddComponent<BoxCollider2D>();
            BoxCollider2D Box = Obj.GetComponent<BoxCollider2D>();
            Vector2 Size = new Vector2(1.5f, 2.0f);
            Box.size = Size;
            Box.isTrigger = true;
        }
        //세번째 줄 9개
        for(int i=23; i<32; ++i)
        {
            GameObject Tmp = GameObject.Find("Tile");

            GameObject Obj = Instantiate(TilePrefab1);
            Obj.transform.name = "Tile " + i;
            Obj.transform.parent = Tmp.transform;
            Vector2 Pos= new Vector2(13.0f, 3.74f);
            Pos.x += (i - 23) * 1.2f;
            Obj.transform.position = Pos;
            Obj.AddComponent<BoxCollider2D>();
            BoxCollider2D Box = Obj.GetComponent<BoxCollider2D>();
            Vector2 Size = new Vector2(1.5f, 2.0f);
            Box.size = Size;
            Box.isTrigger = true;
        }
        //세로줄 12개
        Swap = 0;
        for (int i=32; i<44; ++i)
        {
            int Tmp = 1;
            if (Swap == 2) Tmp = Tmp * -1;
            //Tmp가 1일땐 우측, -1일땐 좌측
            //23.72 ,3.76
            
            
            ++Swap;
        }
        
         
    }
}
