using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//자동으로 해당 컴포넌트를 추가함
[RequireComponent(typeof(Rigidbody))]


public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*2000);
    }
    
     private void OnCollisionEnter(Collision collision)
     {
         if (collision.transform.name == "Wall")
             Destroy(this.gameObject);
     }

    
}
