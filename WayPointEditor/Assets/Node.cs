using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(SphereCollider))]
public class Node : MonoBehaviour
{
    public Node NextNode;
    public int Index = 0;

    private void Start()
    {
        transform.tag = "Node";

        SphereCollider Coll = transform.GetComponent<SphereCollider>();

        Coll.radius = 0.2f;
    }
}
[CustomEditor(typeof(Node))]
public class NodeEditor : Editor
{
    private void OnSceneGUI()
    {
        Node t = (Node)target;

        Handles.color = Color.red;
        if(t.NextNode!=null)
            Handles.DrawLine(t.transform.position,t.NextNode.transform.position);

    }
}