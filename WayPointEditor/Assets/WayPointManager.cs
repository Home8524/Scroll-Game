using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    private static WayPointManager Instance = null;
    public static WayPointManager Getinstance()
    {
        if (Instance == null)
            Instance = new WayPointManager();
        return Instance;
    }

    public int NodeNumber = 0;
    public int MaxNumber = 0;
}
