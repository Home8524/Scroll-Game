using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    
    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");

        if(Hor==1.0f)
            this.transform.Rotate(Vector3.up,0.5f);   
        if(Hor == -1.0f)
            this.transform.Rotate(Vector3.up, -0.5f);
    }
}
