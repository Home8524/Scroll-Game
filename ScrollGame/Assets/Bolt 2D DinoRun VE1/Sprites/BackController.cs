using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour
{
    Vector3 mainCameraSpeed;
    Animator Anim;
    bool Jump = false;

    private void Start()
    {
        Anim = transform.GetComponent<Animator>();
        mainCameraSpeed = Vector3.right * 10.0f;
    }
    void Update()
    {
        transform.position += mainCameraSpeed*Time.deltaTime;
        
        if(Input.GetKeyUp(KeyCode.Space))
            {
              //  Rigidbody Rigid = transform.GetComponent<Rigidbody>();
              //  Rigid.AddForce(Vector3.up* 300.0f);
                transform.Rotate(Vector3.zero);
                Jump = true;
                Anim.SetBool("Jump", true);
            }
    }

}
