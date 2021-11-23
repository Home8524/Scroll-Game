using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody Rigid;
    private void Start()
    {
        Rigid = GameObject.Find(transform.name).GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Ground")
        {
            transform.position= new Vector3(
                Random.Range(
                    WayPointManager.GetInstance().PointA.x,
                    WayPointManager.GetInstance().PointB.x),
                    5.0f,
                Random.Range(
                    WayPointManager.GetInstance().PointA.y,
                    WayPointManager.GetInstance().PointB.y));
        }
        else
        {
            Destroy(Rigid);
        }
    }

}
