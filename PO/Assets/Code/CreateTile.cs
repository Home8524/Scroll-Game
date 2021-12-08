using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    [SerializeField] private GameObject TilePrefab1;
    [SerializeField] private GameObject PlayerPrefab1;
    [SerializeField] private GameObject PlayerPrefab2;
    private void Awake()
    {
        TilePrefab1 = Resources.Load("Prefabs/b1") as GameObject;
        PlayerPrefab1 = Resources.Load("Prefabs/PlayerBall1") as GameObject;
        PlayerPrefab2 = Resources.Load("Prefabs/PlayerBall2") as GameObject;
    }
    void Start()
    {
        //Time Create
        for(int i=0;i<12;++i)
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
                //Vector2 Size = new Vector2(5.0f, 5.0f);
                Box.size = Size;
               //Vector2 Offset = new Vector2(0.5f, -0.8f);
               //Box.offset = Offset;
                Box.isTrigger = true;

            }    
        }

        
           //Player Create
           for (int i = 0; i < 2; ++i)
           {
            GameObject PlayerParent = GameObject.Find("Player");
                if(i==0)
                {
                    GameObject Obj = Instantiate(PlayerPrefab1);
                    Obj.transform.name = "PlayerBall" + (i + 1);
                    Obj.transform.parent = PlayerParent.transform;
                }
           
                else
                {
                    GameObject Obj = Instantiate(PlayerPrefab2);
                    Obj.transform.name = "PlayerBall" + (i + 1);
                    Obj.transform.parent = PlayerParent.transform;
                }
           }
         
    }
}
