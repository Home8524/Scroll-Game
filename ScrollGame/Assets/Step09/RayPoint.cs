using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPoint : MonoBehaviour
{
    public GameObject MainCamera;

    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            // public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance);
            // ������ , ���� , �ǰݴ�� ���� , �ִ�Ÿ�

            // Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance);
            // ������.�߻�Ǵ� ���� , �ǰݴ�� ���� , �ִ�Ÿ�
            if (Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                //DrawLine(Vector3 start, Vector3 end, Color color);
                //Debug.DrawLine(MainCamera.transform.position, hit.point, Color.red,0.02f);
                Debug.DrawLine(
                    transform.position,
                    Vector3.forward * 5.0f,
                    Color.red,0.2f
                    );
                if(hit.transform.tag == "Enemy")
                {
                    Debug.Log("Enemy "+hit.transform.name+"�� ã��");
                }
            }
        }
    }
}
