using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test))]
public class TestEditer : Editor
{
    private void OnSceneGUI()
    {
        Test t = (Test)target;

        Handles.DrawWireArc(
            t.transform.position,
            Vector3.up, Vector3.forward,
            360.0f,
            t.Radius
            );
    }
}

