using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    [SerializeField] GameObject P1;
    private void Start()
    {
        P1 = GameObject.Find("PlayerBall1") as GameObject;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("World");
        }
    }
    private void FixedUpdate()
    {
        transform.RotateAround(P1.transform.position, Vector3.back, 3.5f);
    }
}
