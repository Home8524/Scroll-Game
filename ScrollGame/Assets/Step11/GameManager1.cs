using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    private void Awake()
    {
        WayPointManager.GetInstance();
    }
}
