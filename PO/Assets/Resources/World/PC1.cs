using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC1 : MonoBehaviour
{
    [SerializeField] GameObject P1;
    public GameObject Switch;
    private bool PressKey;
    [SerializeField] private GameObject BoxPrefab;

    private void Awake()
    {
        BoxPrefab = Resources.Load("Prefabs/ChangeLightBox") as GameObject;
    }
    private void Start()
    {
        P1 = GameObject.Find("PlayerBall2");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PressKey = true;
        else
            PressKey = false;
    }
    private void FixedUpdate()
    {
        if(!GameObject.Find("Switch"))
        {
            transform.RotateAround(P1.transform.position, Vector3.back, 3.5f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!GameObject.Find("Switch") && PressKey)
        {
            float Tmp = Vector3.Distance(P1.transform.position, collision.transform.position);
            //Debug.Log(Tmp);
            if(Tmp<=1.5f && Tmp != 0.0f)
            {
                if(collision.transform.childCount == 0)
                {
                    GameObject Obj = Instantiate(BoxPrefab);
                    Obj.transform.position = collision.transform.position;
                    Obj.transform.parent = collision.transform;
                }
                transform.position = collision.transform.position;
                Switch.SetActive(true);
            }
        }
    }
}
