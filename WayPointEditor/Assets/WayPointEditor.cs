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
        NodeObj.AddComponent<GetGizmo>();
       // NodeObj.AddComponent<Node>();
        Node CurrentNode = NodeObj.AddComponent<Node>();
        CurrentNode.Index = ParentNode.transform.childCount - 1;

        while(true)
        {
            NodeObj.transform.position = new Vector3(
                Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
            
            float Distance = 1000.0f;

            if(ParentNode.transform.childCount>1)
            {
                Node PrevioudsNode =
                    ParentNode.transform.GetChild(ParentNode.transform.childCount - 2)
                    .GetComponent<Node>();

                PrevioudsNode.NextNode = ParentNode.transform.GetChild(
                    ParentNode.transform.childCount-1).GetComponent<Node>();

                CurrentNode.NextNode =
                    ParentNode.transform.GetChild(0).GetComponent<Node>();
                Distance = Vector3.Distance(
                    PrevioudsNode.transform.position, CurrentNode.transform.position);
            }

            if (Distance > 1.5f)
                break;

        
        }
    }

}
