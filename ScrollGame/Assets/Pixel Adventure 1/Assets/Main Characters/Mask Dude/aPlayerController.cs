using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aPlayerController : MonoBehaviour
{

    Animator Anim;

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
    }
}
