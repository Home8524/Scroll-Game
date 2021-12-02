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
                Rigidbody2D Rigid = transform.GetComponent<Rigidbody2D>();
                Rigid.AddForce(Vector3.up* 300.0f);
                transform.Rotate(Vector3.zero);
                Jump = true;
                Anim.SetBool("Jump", true);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Wall")
            Debug.Log("Ãæµ¹");
    }
}
