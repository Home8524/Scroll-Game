using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject Target;

    [SerializeField] private Vector3 Offset;

    //카메라의 최대 줌 위치
    [SerializeField] private Vector3 MaxPoint;
    [SerializeField] private Vector3 MinPoint;
    //카메라 속도
    private Vector3 Velocity;


    private bool ShakeCamera;

    private LayerMask PlayerMask;

    [Range(0.0f,1.0f)]
    private float Radius;

    [Range(0.0f,1.0f)]
    public float Distance;

    private float flag;
    private void Awake()
    {
       //PlayerMask =LayerMask.NameToLayer("Player");
       //Camera.main.cullingMask = (1 << PlayerMask)-1;
    }
    private void Start()
    {

        Offset = new Vector3(0.0f,5.0f,-8.0f);

        MaxPoint = new Vector3(0.0f,17.5f,-17.5f);
        MinPoint = new Vector3(0.0f, 1.7f, -1.7f);
        Distance = 0.5f;

        Velocity = Vector3.zero;


        ShakeCamera = false;

        Radius = 1.0f;

        flag = 0;
    }

    private void Update()
    {

        MouseWheel();

        //Distance 최대값 고정
        Distance = Mathf.Clamp(Distance,0.0f, 1.0f);
       
        float Hor = Input.GetAxis("Horizontal")*-1;
        
        //선형 보간
        if(flag == 0)
        {
            transform.position = Vector3.Lerp(
                Target.transform.position+MaxPoint,
                Target.transform.position+MinPoint,
                Distance);
            flag = 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
            flag = 0;
        transform.RotateAround(Target.transform.position,
            Vector3.up,
            Hor * 50.0f * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation((Target.transform.position-transform.position)
            .normalized),
            Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera = !ShakeCamera;
        }

        if(ShakeCamera)
        {
            Vector3 Tmp = new Vector3(
                Random.Range(-0.1f,0.1f) * Radius,
                Random.Range(-0.1f,0.1f) * Radius,
                0.0f
                );
            transform.position += Tmp;

        }

        
        if(Input.GetMouseButton(0))
        {
            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            CurrentRotate.y += Input.GetAxis("Mouse X")*50.0f;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                CurrentQuaternion,
                Time.deltaTime * 5.0f
                );
        }
        
        void MouseWheel()
        {
            float Wheel = Input.GetAxis("Mouse ScrollWheel") *-1;
            if(Wheel!=0)
            {
              //Distance = Mathf.Lerp(
              //    Distance,
              //    Distance - Wheel*Time.deltaTime,
              //    100.0f);
                Distance -= Wheel*Time.deltaTime*10.0f;

                transform.position = Vector3.Lerp(
                Target.transform.position + MaxPoint,
                Target.transform.position + MinPoint,
                Distance);
            }
        }
    }
}
