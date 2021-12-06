using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("�ӵ�, ������")]

    [SerializeField] [Range(0f, 10f)] private float speed = 1;
    [SerializeField] [Range(0f, 10f)] private float radius = 1;

    private float runningTime = 0;
    private Vector2 newPos = new Vector2();

    
    private void Update()
    {
        runningTime += Time.deltaTime * speed;
        float x = radius * Mathf.Cos(runningTime);
        float y = radius * Mathf.Sin(runningTime);
        newPos = new Vector2(x, y);
        this.transform.position = newPos;
    }
}
