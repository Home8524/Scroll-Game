using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerViewController : MonoBehaviour
{
    
    void Start()
    {

    }

    private void Update()
    {
        //** Min -1   Max 1À» ¹ÝÈ¯
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
            Hor * 10.0f * Time.deltaTime,
            0.0f,
            Ver * 10.0f * Time.deltaTime
            );
        if (Input.GetKey(KeyCode.Q))
            this.transform.Rotate(Vector3.up, -0.5f);
        if (Input.GetKey(KeyCode.E))
            this.transform.Rotate(Vector3.up, 0.5f);
    }
}