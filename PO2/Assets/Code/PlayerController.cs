using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject Player;
    Animator Anim;
    [SerializeField] float Speed;

    private void Start()
    {
        Player = GameObject.Find("Chef");
        Anim = Player.transform.GetComponent<Animator>();
        Speed = 5.0f;
    }
    private void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        if (Hor != 0 || Ver != 0)
            Anim.SetBool("Walk", true);
        else
            Anim.SetBool("Walk", false);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Anim.SetBool("Run", true);
            Speed = 10.0f;
            Invoke("RunStart",1.0f);
        }
        Player.transform.Translate(
            Hor * Speed * Time.deltaTime,
            0,
            Ver * Speed * Time.deltaTime);
    }
    void RunStart()
    {
        Speed = 5.0f;
        Anim.SetBool("Run", false);
    }
}
