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

        //ī�޶�� Ÿ���� �Ÿ�
        ZoomDistancce = 0.0f;

        //ó�� �����Ҷ� ȭ�� �÷��̾� �ٶ󺸰���
        //��� �ٶ󺸰��ϸ� ī�޶� �¿� ������ �Ұ���
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

        //�ܰ� ī�޶�����
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
            //����ȸ����
            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            //ȸ���� + ���콺 �Է°�
            CurrentRotate.y += Input.GetAxis("Mous X") * 5;

            //���ʹϾ� ��ȯ
            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            CurrentQuaternion.z = 0;
            
            //ȸ�� �������ϰ� �Ϸ��� ��
            transform.rotation = Quaternion.Slerp(
                transform.rotation, CurrentQuaternion, 5 * Time.deltaTime);
        }
    }

    void StartShake()
    {
        //0~1�� ������ �� ��ȯ
        Vector3 CameraPos = new Vector3(Random.value * ShakeRadius,
            Random.value * ShakeRadius);

        //ī�޶��� ��ġ�� ���� ���� ����
        Vector3 CurrentCameraPos = new Vector3(
            this.transform.position.x + CameraPos.x,
            this.transform.position.y + CameraPos.y,
            this.transform.position.z);

        MinimapCarema.transform.position = CurrentCameraPos;
    }

    void StopShake()
    {
        //�������� �Լ� �� ���
        CancelInvoke("StartShake");

        //���� ����� �����Ҷ� ī�޶� ��ġ��
        MinimapCarema.transform.position = this.transform.position;
    }
}
