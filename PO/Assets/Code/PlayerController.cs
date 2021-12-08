using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("�ӵ�, ������")]

    [SerializeField] [Range(0f, 10f)] private float speed = 5.0f;
    [SerializeField] [Range(0f, 10f)] private float radius = 1.3f;
    
    private float runningTime = 0;
    private Vector2 newPos = new Vector2();
    private Vector2 PosSave = new Vector2();
    private int MyName;
    private bool PressKey = false;
    private GameObject LightPrefabs;

    private void Awake()
    {
        LightPrefabs = Resources.Load("Prefabs/Light") as GameObject;
    }
    private void Start()
    {
        Vector2 Tmp = new Vector2();
        Tmp.x = transform.position.x;
        Tmp.y = transform.position.y;
        
        //���� Ÿ���� ��ġ ����
        Singleton.GetInstance.PosSave = Tmp;
        MyName = 0;
    }
    
    private void FixedUpdate()
    {
        //�۾��� ������ ���ѹ� �޾ƿ�
        int BallSet = Singleton.GetInstance.BallSet;

        //���� ȸ���ؾ��� ���� �´��� Ȯ���ϰ� ������ ȸ��
        if (BallSet == MyName)
        {
            PosSave = Singleton.GetInstance.PosSave;
            runningTime += Time.deltaTime * speed;
            float x = radius * Mathf.Cos(runningTime) * -1.0f + PosSave.x;
            float y = radius * Mathf.Sin(runningTime) + PosSave.y;
            newPos = new Vector2(x, y);
            
            this.transform.position = newPos;
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
                
                    //�ٽ� ȸ���ϱ� �����Ҷ��� ó�� ȸ�� ������ġ���� ������ ���� 0���� �ʱ�ȭ
                    runningTime = 0;
                }
            }    
         

    }
}
