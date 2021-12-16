using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    //�ؽ�Ʈ ������
    private GameObject TextPrefabs;

    //���� ��ȯ�� ȸ������ ������ ��
    private float WayRoute;

    //������
    private GameObject RouteLine;

    GameObject P1;
    GameObject P2;
    private TrailRenderer Trail;

    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;
    [SerializeField] private Text CanvansText;
    private float Timer;
    private void Awake()
    {
        LightPrefabs = Resources.Load("Prefabs/Light") as GameObject;
        TextPrefabs = Resources.Load("Prefabs/Great") as GameObject;
    }
    private void Start()
    {
        RouteLine = GameObject.Find("BlueRoute");
        Timer = 0;
        //���ε�� Ÿ�ӽ����� 0->1�� �����Ͽ� �����
        Time.timeScale = 1;
        CanvansText = GameObject.Find("Ready").GetComponent<Text>();
        //ĵ���� ��Ȱ��ȭ
        Canvas1.SetActive(false);
        Canvas3.SetActive(false);
        Vector2 Tmp = new Vector2(5.8f,5.7f);   
        //���� Ÿ���� ��ġ ����
        Singleton.GetInstance.PosSave = Tmp;
        MyName = 0;
        WayRoute = -1.0f;
        P1 = GameObject.Find("PlayerBall1");
        P2 = GameObject.Find("PlayerBall2");
        Trail = transform.GetComponent<TrailRenderer>();
        Trail.sortingLayerName = "2";
        Trail.sortingOrder = 0;
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
            transform.RotateAround(P2.transform.position, Vector3.back, 5.0f);
            RouteLine.transform.localScale = new Vector3(0.0f,0.0f,0.0f);
        }
        //�ƴҽ� ������ Ȯ��
        else
        {
            //blue
        }
        //�����̽��ٸ� ���� ������ PressKey�� true
        if (Input.GetKeyDown(KeyCode.Space) && Singleton.GetInstance.BallSet == MyName)
        {
            PressKey = true;
        }
        else PressKey = false;

        //UI
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Canvas2.SetActive(false);
           Canvas3.SetActive(true);
           Canvas1.SetActive(true);
            Time.timeScale = 0;
        }

        //Ready Action
        Timer += Time.deltaTime*1.0f;
        if (Timer >= 1.2f)
            CanvansText.gameObject.SetActive(false);
        else if (Timer >= 1.0f)
            CanvansText.text = "����!";
        else if (Timer >= 0.75f)
            CanvansText.text = "1";
        else if (Timer >= 0.5f)
            CanvansText.text = "2";
        else if (Timer >= 0.25f)
            CanvansText.text = "3";

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
                //������ ���� Ÿ�Ͽ� ����
                GameObject Obj = Instantiate(LightPrefabs);
                Obj.transform.position = Singleton.GetInstance.PosSave;
                GameObject LightBox = GameObject.Find("LightBox");
                Obj.transform.parent = LightBox.transform;

                //������ �ؽ�Ʈ ���
                GameObject TextObj = Instantiate(TextPrefabs);
                Vector2 Pos = Singleton.GetInstance.PosSave;
                Pos.x -= 0.5f;
                Pos.y += 1.3f;
                GameObject TextBox =new GameObject("TextBox");
                TextObj.transform.name = "Text "+Singleton.GetInstance.TimeNum;
                TextObj.transform.parent = TextBox.transform;
                TextObj.transform.position = Pos;

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

                int TileNum = Singleton.GetInstance.TimeNum;
                if (TileNum == 23 || TileNum == 14 || TileNum > 32 && TileNum < 45
                || TileNum > 48 && TileNum < 61 || TileNum > 102 && TileNum < 106
                || TileNum > 110 && TileNum < 114 || TileNum > 118 && TileNum < 122
                || TileNum > 126 && TileNum < 130)
                    BackGround.transform.Translate(0.0f, -0.5f, 0.0f);
                else if (TileNum > 64 && TileNum < 91)
                    BackGround.transform.Translate(0.4f * WayRoute * -1.0f, 0.0f, 0.0f);
                else if (TileNum > 130 && TileNum < 161)
                {
                    int TileCheck = (TileNum - 130) % 8;
                    if (TileCheck == 7)
                        BackGround.transform.Translate(0.0f, -0.5f, 0.0f);
                    else
                        BackGround.transform.Translate(0.8f * WayRoute * -1.0f, 0.0f, 0.0f);
                }
                else
                    BackGround.transform.Translate(1.1f * WayRoute * -1.0f, 0.0f, 0.0f);
            }
        }    
    }
}
