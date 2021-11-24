using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("面倒");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("面倒吝");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("面倒 场");
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("面倒");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("面倒吝");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("面倒 场");
    }
}
