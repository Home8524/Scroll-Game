using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour
{
    Vector3 mainCameraSpeed;
    Animator Anim;
   [SerializeField] private bool Hit;
    private void Start()
    {
        Hit = false;
        Anim = transform.GetComponent<Animator>();
        mainCameraSpeed = Vector3.right * 10.0f;
    }
    void Update()
    {
        if(!Hit)
            transform.position += mainCameraSpeed*Time.deltaTime;
        
        if(Input.GetKeyUp(KeyCode.Space))
            {
                Rigidbody2D Rigid = transform.GetComponent<Rigidbody2D>();
                Rigid.AddForce(Vector3.up* 400.0f);
                transform.Rotate(Vector3.zero);
                Anim.SetBool("Jump", true);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Anim.SetBool("Jump", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            Anim.SetBool("Hit", true);
            Hit = true;
        }
    }
}
