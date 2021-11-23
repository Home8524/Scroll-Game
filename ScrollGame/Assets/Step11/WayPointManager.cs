using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    private static WayPointManager Instance = null;
    private static GameObject Container = null;

    public static WayPointManager GetInstance()
    {
        if(Instance==null)
        {
            Container = new GameObject("WaypPointManager");
            Instance = new WayPointManager();

            Instance = Container.AddComponent(typeof(WayPointManager)) as WayPointManager;
        }

        return Instance;
    }

    [HideInInspector] public Vector2 PointA;
    [HideInInspector] public Vector2 PointB;
}
