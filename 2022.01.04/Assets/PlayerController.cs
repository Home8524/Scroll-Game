using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        var Hor = Input.GetAxis("Horizontal");

        transform.RotateAround(
            this.transform.position,
            Vector3.up,
            Hor*50.0f*Time.deltaTime
            );
    }
}
