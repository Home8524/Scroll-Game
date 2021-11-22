using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WayPoint))]
public class WayPointEditor : Editor
{
    private void OnSceneGUI()
    {
        WayPoint va = (WayPoint)target;

        Handles.color = Color.green;
        for (int i = 1; i < va.WayPointList.Count; ++i)
        {
            //DrawLine(Vector3 p1, Vector3 p2);
            Handles.DrawLine(va.WayPointList[i-1].transform.position, va.WayPointList[i].transform.position);

        }
        Handles.DrawLine(va.WayPointList[0].transform.position, va.WayPointList[va.WayPointList.Count-1].transform.position);
    }
}
