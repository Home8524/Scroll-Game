using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WayPointEditor : EditorWindow
{
    [MenuItem("Tools/WayPoint Editor")]
    
    static public void Initialize()
    {
        WayPointEditor Window = GetWindow<WayPointEditor>();
        Window.Show();

    }
    [Tooltip("")]
    public GameObject ParentNode = null;

    private void OnGUI()
    {
        SerializedObject Obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(
            Obj.FindProperty("ParentNode"));
        
        if(ParentNode == null)
        {
            EditorGUILayout.HelpBox("root node X",MessageType.Warning);
        }
        else
        {

            // GUILayout.Width();, GUILayout.Height();
            // GUILayout.MaxHeight(); GUILayout.MinHeight();

            EditorGUILayout.BeginVertical();

           if( GUILayout.Button("Create Node") )
            {
                CreateNode();
            }
            
            EditorGUILayout.EndVertical();
        
        }

        Obj.ApplyModifiedProperties();

    }
    public void CreateNode()
    {
        GameObject NodeObj = new GameObject("Node " + ParentNode.transform.childCount);
        NodeObj.transform.parent = ParentNode.transform;
        NodeObj.transform.tag = "Node";
        NodeObj.AddComponent<GetGizmo>();
        NodeObj.AddComponent<Node>();
        if (ParentNode.transform.childCount == 1)
        {
            NodeObj.AddComponent<BoxCollider>();
            NodeObj.AddComponent<Rigidbody>();
            Rigidbody Rigid = NodeObj.GetComponent<Rigidbody>();
            Rigid.useGravity = false;
        }
        NodeObj.transform.position = new Vector3(
            Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));

        int Tmp = WayPointManager.Getinstance().MaxNumber;
        ++Tmp;
        WayPointManager.Getinstance().MaxNumber = Tmp;
        Node node = NodeObj.GetComponent<Node>();

        if(ParentNode.transform.childCount>1)
        {
            node.NextNode = ParentNode.transform.GetChild(
                ParentNode.transform.childCount-2).GetComponent<Node>();

            GameObject FirstObj = GameObject.Find("Node " + 0);
            Node FirstNode = FirstObj.GetComponent<Node>();
            FirstNode.NextNode = node;
        }
    }

}
