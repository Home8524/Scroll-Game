using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [Header("속도, 반지름")]

    [SerializeField] [Range(0f, 10f)] private float speed = 5.0f;
    [SerializeField] [Range(0f, 10f)] private float radius = 1.3f;

    //FixedUpdate마다 증가하여 Cos , Sin에 넣어줄 값
    private float runningTime = 0;
    //회전한 좌표 저장용
    private Vector2 newPos = new Vector2();
    //현재 안착한 Tile 위치
    private Vector2 PosSave = new Vector2();
    //회전할 Target 식별
    private int MyName;
    //키보드 입력 확인
    private bool PressKey = false;

    //통과한 타일에 빛남겨주는 이펙트
    private GameObject LightPrefabs;

    //방향 전환시 회전값에 곱해줄 값
    private float WayRoute;

    GameObject P1;
    GameObject P2;

    private void Awake()
    {
        LightPrefabs = Resources.Load("Prefabs/Light") as GameObject;
    }
    private void Start()
    {
        Vector2 Tmp = new Vector2();
        Tmp.x = transform.position.x;
        Tmp.y = transform.position.y;

        //현재 타일의 위치 저장
        Singleton.GetInstance.PosSave = Tmp;
        if (transform.name == "PlayerBall1")
            MyName = 0;
        else
            MyName = 1;
        WayRoute = -1.0f;

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
            runningTime += Time.deltaTime * speed;
            float x = radius * Mathf.Cos(runningTime) * WayRoute + PosSave.x;
            float y = radius * Mathf.Sin(runningTime) * WayRoute * -1.0f + PosSave.y;
            newPos = new Vector2(x, y);

            this.transform.position = newPos;
        }
        //스페이스바를 눌렀다가 뗀 순간만 PressKey가 true
        if (Input.GetKeyUp(KeyCode.Space) && Singleton.GetInstance.BallSet == MyName)
        {
            PressKey = true;
        }
        else PressKey = false;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        string Name = "Tile " + Singleton.GetInstance.TimeNum;

        //충돌시 충돌한 타일명이 지금 충돌해야할 타일인지 확인 , 스페이스바 입력여부 확인
        if (PressKey && collision.transform.name == Name)
        {
            int BallSet = Singleton.GetInstance.BallSet;

            //충돌한 transform의 tag가 Tile 이고 현재 회전중인 공과 부딫힌게 맞는지 확인
            if (collision.transform.tag == "Tile" && BallSet == MyName)
            {
                Debug.Log(Name + "성공");

                //성공시 이전 타일에 빛남
                GameObject Obj = Instantiate(LightPrefabs);
                Obj.transform.position = Singleton.GetInstance.PosSave;
                GameObject LightBox = GameObject.Find("LightBox");
                Obj.transform.parent = LightBox.transform;

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

                //다시 회전하기 시작할때도 처음 회전 시작위치에서 돌리기 위해 0으로 초기화
                runningTime = 0;

                //지나간 Tile의 Collider 파괴해서 재호출 X
                GameObject BoxCol = GameObject.Find(Name);
                BoxCollider2D Coll = BoxCol.GetComponent<BoxCollider2D>();
                Destroy(Coll);

                //카메라 이동에 맞춰 BackGround 소폭 이동
                GameObject BackGround = GameObject.Find("BackGround");
                BackGround.transform.Translate(0.8f * WayRoute * -1.0f, 0.0f, 0.0f);

                if (Singleton.GetInstance.TimeNum == 14)
                    BackGround.transform.Translate(0.0f, -1.0f, 0.0f);

                //runningTime = 0.3333333f*5;

            }
        }


    }
}
