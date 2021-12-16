using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    //현재 안착한 Tile 위치
    private Vector2 PosSave = new Vector2();
    //회전할 Target 식별
    private int MyName;
    //키보드 입력 확인
    private bool PressKey = false;

    //통과한 타일에 빛남겨주는 이펙트
    private GameObject LightPrefabs;

    //텍스트 프리펩
    private GameObject TextPrefabs;

    //방향 전환시 회전값에 곱해줄 값
    private float WayRoute;

    //판정선
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
        //리로드시 타임스케일 0->1로 변경하여 재시작
        Time.timeScale = 1;
        CanvansText = GameObject.Find("Ready").GetComponent<Text>();
        //캔버스 비활성화
        Canvas1.SetActive(false);
        Canvas3.SetActive(false);
        Vector2 Tmp = new Vector2(5.8f,5.7f);   
        //현재 타일의 위치 저장
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
        //카메라도 같이 움직이게 해주려고 값 받음
        Singleton.GetInstance.WayRoute = WayRoute;

        if (Singleton.GetInstance.TimeNum == 14)
            WayRoute = 1.0f;
        if (Singleton.GetInstance.TimeNum == 23)
            WayRoute = -1.0f;

        //작업을 수행할 볼넘버 받아옴
        int BallSet = Singleton.GetInstance.BallSet;

        //현재 회전해야할 공이 맞는지 확인하고 맞을시 회전
        if (BallSet == MyName)
        {
            PosSave = Singleton.GetInstance.PosSave;
            transform.RotateAround(P2.transform.position, Vector3.back, 5.0f);
            RouteLine.transform.localScale = new Vector3(0.0f,0.0f,0.0f);
        }
        //아닐시 판정선 확대
        else
        {
            //blue
        }
        //스페이스바를 누른 순간만 PressKey가 true
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
            CanvansText.text = "시작!";
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
       //충돌시 충돌한 타일명이 지금 충돌해야할 타일인지 확인 , 스페이스바 입력여부 확인
       if (PressKey&&collision.transform.name==Name)
       {
            int BallSet = Singleton.GetInstance.BallSet;
            //충돌한 transform의 tag가 Tile 이고 현재 회전중인 공과 부딫힌게 맞는지 확인
            if (collision.transform.tag == "Tile" && BallSet == MyName)
            {
                //성공시 이전 타일에 빛남
                GameObject Obj = Instantiate(LightPrefabs);
                Obj.transform.position = Singleton.GetInstance.PosSave;
                GameObject LightBox = GameObject.Find("LightBox");
                Obj.transform.parent = LightBox.transform;

                //성공시 텍스트 띄움
                GameObject TextObj = Instantiate(TextPrefabs);
                Vector2 Pos = Singleton.GetInstance.PosSave;
                Pos.x -= 0.5f;
                Pos.y += 1.3f;
                GameObject TextBox =new GameObject("TextBox");
                TextObj.transform.name = "Text "+Singleton.GetInstance.TimeNum;
                TextObj.transform.parent = TextBox.transform;
                TextObj.transform.position = Pos;

                //성공시 타일에 지금 회전중이던 공 붙임
                transform.position = collision.transform.position;
                Vector2 SavePosition;
                SavePosition.x = transform.position.x;
                SavePosition.y = transform.position.y;

                //현재 도달중인 타일 위치 갱신
                Singleton.GetInstance.PosSave = SavePosition;

                //Player1 ~ Plaeyr2 Switch
                if (Singleton.GetInstance.BallSet == 0)
                    Singleton.GetInstance.BallSet = 1;
                else
                    Singleton.GetInstance.BallSet = 0;

                //이동 , 카메라 연산을 위해 타일넘버 갱신
                Singleton.GetInstance.TimeNum++;

                //지나간 Tile의 Collider 파괴해서 재호출 X
                GameObject BoxCol = GameObject.Find(Name);
                BoxCollider2D Coll = BoxCol.GetComponent<BoxCollider2D>();
                Destroy(Coll);

                //카메라 이동에 맞춰 BackGround 소폭 이동
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
