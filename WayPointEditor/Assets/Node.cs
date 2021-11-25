using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Node : MonoBehaviour
{
    public Node NextNode;

}
[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    private void OnSceneGUI()
    {
        Node t = (Node)target;

        Handles.color = Color.red;
        Handles.DrawLine(t.transform.position,t.NextNode.transform.position);

    }
}