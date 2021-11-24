using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
   [SerializeField] private Vector3 Direction;
    private float Speed = 0.0f;
   [SerializeField] private bool Moving = false;
    private float fTime = 0.0f;

    private void Start()
    {
        fTime = 5.0f;
        Direction = GetDirection();
        Speed = 5.0f;
       // WayPointManager.GetInstance().TargetPoint
    }

    Vector3 GetDirection()
    {
        Moving = true;

        Vector3 Node = WayPointManager.GetInstance().TargetPoint;

        Vector3 Result =  (Node - transform.position).normalized;

        Result.y = 0.0f;

        return Result;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Node"&&Moving)
        {

            int NodeNumber = WayPointManager.GetInstance().NodeNumber;
            ++NodeNumber;
            Moving = false;
            if(NodeNumber>4)
            {
                NodeNumber = 0;
            }
            WayPointManager.GetInstance().NodeNumber = NodeNumber;

        }

    }
    void Update()
    {
        if(Moving)
        {
            transform.Translate(Direction * Speed * Time.deltaTime);

            //transform.LookAt(Direction);
        }
        else
        {
            fTime = 2.0f;

            StartCoroutine("Behaviour");
        }
    }

    IEnumerator Behaviour()
    {
        yield return new WaitForSeconds(fTime);
        Direction = GetDirection();
    }
}
