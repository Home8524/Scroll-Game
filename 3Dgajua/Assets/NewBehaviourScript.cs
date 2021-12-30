using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator Anim;

    private void Awake()
    {
        Anim = transform.GetComponent<Animator>();
    }
    void Update()
    {
        Anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        Anim.SetFloat("Hor", Input.GetAxis("Horizontal"));
    }
}
