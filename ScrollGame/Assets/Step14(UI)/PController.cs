using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.GetInstance.Initialize();
    }
    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");

        float Vtr = Input.GetAxisRaw("Vertical");

        transform.Translate(Hor*5.0f*Time.deltaTime, 0.0f, Vtr * 5.0f * Time.deltaTime);
    }
}
