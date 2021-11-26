using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera MinimapCarema;

    [SerializeField] [Range(0.01f, 0.1f)] float ShakeRadius;
    [SerializeField] [Range(0.01f, 0.1f)] float ShakeTime;

    public GameObject Target;
    private float ZoomDistancce;

    private void Awake()
    {
        MinimapCarema = GetComponent<Camera>();
    }

    private void Start()
    {
        this.transform.position = new Vector3(0.0f, 45.0f, 0.0f);

        ShakeTime = 0.5f;

        ShakeRadius = 0.1f;

        //카메라와 타깃의 거리
        ZoomDistancce = 0.0f;

        //처음 시작할때 화면 플레이어 바라보게함
        //계속 바라보게하면 카메라 좌우 움직임 불가능
       // this.transform.rotation = Quaternion.LookRotation(
       //     Vector3.Normalize(Target.transform.position - this.transform.position));

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            InvokeRepeating("StartShake", 0f, 0.01f);

        if (Input.GetKeyDown(KeyCode.S))
            Invoke("StopShake", 0.0f);

        MouseWheel();

        CameraHorizontal();

        //줌값 카메라적용
        MinimapCarema.fieldOfView = Mathf.Lerp(
            MinimapCarema.fieldOfView, ZoomDistancce, Time.deltaTime * 4);

        MinimapCarema.transform.position =
            Target.transform.position - Vector3.forward + Vector3.up * 20.0f;


    }

    void MouseWheel()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel") * -1;

        ZoomDistancce += (ScrollWheel * 10);

        if (ZoomDistancce < 20f)
            ZoomDistancce = 20f;

        if (ZoomDistancce > 60f)
            ZoomDistancce = 60f;
    }

    void CameraHorizontal()
    {
        if(Input.GetMouseButton(1))
        {
            //현재회전값
            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            //회전값 + 마우스 입력값
            CurrentRotate.y += Input.GetAxis("Mous X") * 5;

            //쿼터니안 변환
            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            CurrentQuaternion.z = 0;
            
            //회전 스무스하게 하려고 씀
            transform.rotation = Quaternion.Slerp(
                transform.rotation, CurrentQuaternion, 5 * Time.deltaTime);
        }
    }

    void StartShake()
    {
        //0~1중 임의의 수 반환
        Vector3 CameraPos = new Vector3(Random.value * ShakeRadius,
            Random.value * ShakeRadius);

        //카메라의 위치를 흔들기 위해 세팅
        Vector3 CurrentCameraPos = new Vector3(
            this.transform.position.x + CameraPos.x,
            this.transform.position.y + CameraPos.y,
            this.transform.position.z);

        MinimapCarema.transform.position = CurrentCameraPos;
    }

    void StopShake()
    {
        //실행중인 함수 값 취소
        CancelInvoke("StartShake");

        //흔들기 종료시 시작할때 카메라 위치로
        MinimapCarema.transform.position = this.transform.position;
    }
}
