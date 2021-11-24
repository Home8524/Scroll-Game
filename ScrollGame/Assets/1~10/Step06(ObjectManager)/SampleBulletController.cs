using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBulletController : MonoBehaviour
{
    
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000);
    }
    private void OnEnable()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            ObjectManager.Getinstance().GetEnableList.Remove(this.gameObject);
            this.gameObject.SetActive(false);
            ObjectManager.Getinstance().GetDisableList.Push(this.gameObject);
        }
           
    }
}
