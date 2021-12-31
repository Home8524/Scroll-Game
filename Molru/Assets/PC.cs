using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private GameObject HitPoint;
    [SerializeField] private Vector3 CameraPos;
    [SerializeField] private Slider AnchorPoint;
    [SerializeField] private float Damages;

    private void Awake()
    {
        HitPoint = GameObject.Find("Canvas/Slider");
        AnchorPoint = HitPoint.GetComponent<Slider>();

        CameraPos = GameObject.Find("Main Camera").transform.position;
    }

    void Start()
    {
        Speed = 5.0f;
        Damages = 0.005f;
        AnchorPoint.value = AnchorPoint.maxValue;
    }

    void Update()
    {
        float fHor = Input.GetAxis("Horizontal");
        float fVer = Input.GetAxis("Vertical");

        transform.Translate(
            Time.deltaTime * Speed * fHor,
            0,
            Time.deltaTime * Speed * fVer,
            Space.World);

        CameraPos = new Vector3(
            transform.position.x,
            transform.position.y + 1f,
            transform.position.z);

        HitPoint.transform.position = Camera.main.WorldToScreenPoint(CameraPos);


        float MouseWheel = Input.GetAxis("Mouse ScrollWheel");

        if (MouseWheel > 0)
        {
            AnchorPoint.value += Damages;
        }

        if (MouseWheel < 0)
        {
            AnchorPoint.value -= Damages;
        }
    }
}