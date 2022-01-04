using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject Target;

    [SerializeField] private float SmoothTime;

    [SerializeField] private Vector3 Offset;

    private Vector3 Velocity;

    private float ZoomDistance;

    private bool ShakeCamera;

    [Range(0.0f,1.0f)]
    private float Radius;
    private void Start()
    {
        SmoothTime = 0.5f;

        Offset = new Vector3(0.0f,5.0f,-8.0f);

        Velocity = Vector3.zero;

        ZoomDistance = 0.0f;

        ShakeCamera = false;

        Radius = 1.0f;
    }

    private void Update()
    {
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
            transform.position = transform.position + Tmp;

        }

        MouseWheel();

        if(Input.GetMouseButton(0))
        {
            Vector3 CurrentRotate = transform.rotation.eulerAngles;

            CurrentRotate.y += Input.GetAxis("Mouse X")*50.0f;

            Quaternion CurrentQuaternion = Quaternion.Euler(CurrentRotate);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                CurrentQuaternion,
                Time.deltaTime * 5.0f*SmoothTime
                );
        }
        else
        {
            transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(
                (Target.transform.position - transform.position).normalized),
            Time.deltaTime * 5.0f * SmoothTime
            );
        }
        Camera.main.fieldOfView = Mathf.Lerp(
            Camera.main.fieldOfView,
            ZoomDistance,
            Time.deltaTime * 5.0f
            );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            Target.transform.position+Offset,
            ref Velocity,
            SmoothTime
            );

        void MouseWheel()
        {
            float Wheel = Input.GetAxis("Mouse ScrollWheel");

            ZoomDistance -= Wheel*10.0f;

            if (ZoomDistance < 20.0f)
                ZoomDistance = 20.0f;

            if (ZoomDistance > 60.0f)
                ZoomDistance = 60.0f;
        }
    }
}
