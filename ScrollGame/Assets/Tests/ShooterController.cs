using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
          
            this.transform.Rotate(Vector3.left, -0.5f);
            this.transform.Translate(Vector3.down*-0.025f);
        }
        if (Input.GetKey(KeyCode.E))
        {
           this.transform.Rotate(Vector3.left,0.5f);
            this.transform.Translate(Vector3.down * 0.025f);
        }
    }
}
