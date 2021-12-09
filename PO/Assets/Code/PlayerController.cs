using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //���� ������ Tile ��ġ
    private Vector2 PosSave = new Vector2();
    //ȸ���� Target �ĺ�
    private int MyName;
    //Ű���� �Է� Ȯ��
    private bool PressKey = false;

    //����� Ÿ�Ͽ� �������ִ� ����Ʈ
    private GameObject LightPrefabs;

    //���� ��ȯ�� ȸ������ ������ ��
    private float WayRoute;

    GameObject P1;
    GameObject P2;

    private void Awake()
    {
        LightPrefabs = Resources.Load("Prefabs/Light") as GameObject;
    }
    private void Start()
    {
        Vector2 Tmp = new Vector2(7.0f,5.7f);   
        //���� Ÿ���� ��ġ ����
        Singleton.GetInstance.PosSave = Tmp;
        if (transform.name == "PlayerBall1")
            MyName = 0;
        else
            MyName = 1;
        WayRoute = -1.0f;
        P1 = GameObject.Find("PlayerBall1");
        P2 = GameObject.Find("PlayerBall2");
    }
    
    private void FixedUpdate()
    {
        //ī�޶� ���� �����̰� ���ַ��� �� ����
        Singleton.GetInstance.WayRoute = WayRoute;

        if (Singleton.GetInstance.TimeNum == 14)
            WayRoute = 1.0f;
        if (Singleton.GetInstance.TimeNum == 23)
            WayRoute = -1.0f;

        //�۾��� ������ ���ѹ� �޾ƿ�
        int BallSet = Singleton.GetInstance.BallSet;

        //���� ȸ���ؾ��� ���� �´��� Ȯ���ϰ� ������ ȸ��
        if (BallSet == MyName)
        {
            PosSave = Singleton.GetInstance.PosSave;
            if (transform.name=="PlayerBall1")
            {
                transform.RotateAround(P2.transform.position, Vector3.back, 3.0f);
            }
           else
            {
                transform.RotateAround(P1.transform.position, Vector3.back, 3.0f);
            }
        }
        //�����̽��ٸ� �����ٰ� �� ������ PressKey�� true
        if (Input.GetKeyUp(KeyCode.Space) && Singleton.GetInstance.BallSet == MyName)
        {
            PressKey = true;
        }
        else PressKey = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        string Name = "Tile "+Singleton.GetInstance.TimeNum;
      
       //�浹�� �浹�� Ÿ�ϸ��� ���� �浹�ؾ��� Ÿ������ Ȯ�� , �����̽��� �Է¿��� Ȯ��
       if (PressKey&&collision.transform.name==Name)
       {   
                int BallSet = Singleton.GetInstance.BallSet;
                
            //�浹�� transform�� tag�� Tile �̰� ���� ȸ������ ���� �΋H���� �´��� Ȯ��
            if (collision.transform.tag == "Tile" && BallSet == MyName)
                {
                    Debug.Log(Name + "����");

                    //������ ���� Ÿ�Ͽ� ����
                    GameObject Obj = Instantiate(LightPrefabs);
                    Obj.transform.position = Singleton.GetInstance.PosSave;
                    GameObject LightBox = GameObject.Find("LightBox");
                    Obj.transform.parent = LightBox.transform;

                    //������ Ÿ�Ͽ� ���� ȸ�����̴� �� ����
                    transform.position = collision.transform.position;
                    Vector2 SavePosition;
                    SavePosition.x = transform.position.x;
                    SavePosition.y = transform.position.y;

                    //���� �������� Ÿ�� ��ġ ����
                    Singleton.GetInstance.PosSave = SavePosition;

                    //Player1 ~ Plaeyr2 Switch
                    if (Singleton.GetInstance.BallSet == 0)
                        Singleton.GetInstance.BallSet = 1;
                    else
                        Singleton.GetInstance.BallSet = 0;

                    //�̵� , ī�޶� ������ ���� Ÿ�ϳѹ� ����
                    Singleton.GetInstance.TimeNum++;
                    

                    //������ Tile�� Collider �ı��ؼ� ��ȣ�� X
                    GameObject BoxCol = GameObject.Find(Name);
                    BoxCollider2D Coll = BoxCol.GetComponent<BoxCollider2D>();
                    Destroy(Coll);

                    //ī�޶� �̵��� ���� BackGround ���� �̵�
                    GameObject BackGround = GameObject.Find("BackGround");
                    BackGround.transform.Translate(0.8f * WayRoute * -1.0f, 0.0f, 0.0f);

                    if (Singleton.GetInstance.TimeNum == 14)
                        BackGround.transform.Translate(0.0f, -1.0f, 0.0f);


            }
        }    
         

    }
}
