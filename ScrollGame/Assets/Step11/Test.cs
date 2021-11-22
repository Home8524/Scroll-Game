using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Vector2 PointA;
    private Vector2 PointB;
    private Vector2 Radius;
    private Rigidbody Rigid;
    private void Start()
    {
        Radius.x = 5;
        Radius.y = 5;
        Rigid = GameObject.Find(transform.name).GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Ground")
        {
            PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
            PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

            transform.position = new Vector3(Random.Range(PointA.x, PointB.x), 5.0f, Random.Range(PointA.y, PointB.y));
        }
        else
        {
            Destroy(Rigid);
        }
    }

}
