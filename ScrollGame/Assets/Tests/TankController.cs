using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float Speed = 0.0f;

    void Start()
    {
        Speed = 10.0f;
        
    }

    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        this.transform.Translate(
           0.0f,
            0.0f,
            Ver * Speed * Time.deltaTime*-1.0f
            );

        if (Hor==-1)
            this.transform.Rotate(Vector3.up, 0.5f);
        if (Hor==1)
            this.transform.Rotate(Vector3.up,-0.5f);
        
    }
}
