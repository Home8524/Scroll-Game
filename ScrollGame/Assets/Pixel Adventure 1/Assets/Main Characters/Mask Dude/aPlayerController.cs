using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aPlayerController : MonoBehaviour
{

    Animator Anim;
    bool Jump = false;

    void Start()
    {
        Anim = transform.GetComponent<Animator>();
    }
    
    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");

        if(Hor!=0)
        {
            Vector3 Direction = transform.localScale;
            if (transform.localScale.x < 0)
                Direction.x = Hor * transform.localScale.x * -1.0f;
           else
                Direction.x = Hor*transform.localScale.x;

            transform.localScale = Direction;

            Vector3 Tmp = new Vector3(0.0f,0.0f,0.0f);
            Tmp.x = Hor;

            transform.Translate(Tmp*3.0f*Time.deltaTime);
        }

        Anim.SetFloat("Hor", Hor);
        
        //transform.Translate();
        if(Input.GetKeyDown(KeyCode.Space ))
        {
            Anim.SetBool("Hit", true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            Anim.SetBool("Hit", false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Rigidbody2D Rigid = transform.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Vector3.up * 300.0f);
            transform.Rotate(Vector3.zero);
            Jump = true;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ãæµ¹");
    }
}
