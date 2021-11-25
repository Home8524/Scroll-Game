using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private bool Moving = false;
    private float Speed = 5.0f;
    private float fTime = 0.0f;
    [SerializeField] private Vector3 Direction;

    private void Start()
    {
        fTime = 5.0f;
        Direction = GetDirection();
        Speed = 5.0f;
        // WayPointManager.GetInstance().TargetPoint
    }


    Vector3 GetDirection()
    {
        Moving = true;
        int WayNum = WayPointManager.Getinstance().NodeNumber;
        GameObject NodeObj = GameObject.Find("Node " + WayNum);

        Vector3 Result = (NodeObj.transform.position - transform.position).normalized;

        Result.y = 0.0f;

        return Result;
    }
   //private void OnTriggerEnter(Collider other)
   //{
   //
   //    int NodeNumber = WayPointManager.Getinstance().NodeNumber;
   //    Debug.Log(NodeNumber);
   //    Debug.Log(other.transform.tag);
   //    Debug.Log(other.transform.name);
   //    if (other.transform.tag == "Node" && Moving&&other.transform.name=="Node "+ NodeNumber)
   //    {
   //        int Tmp = WayPointManager.Getinstance().MaxNumber;
   //        ++NodeNumber;
   //        Moving = false;
   //        if (NodeNumber > Tmp)
   //        {
   //            NodeNumber = 0;
   //        }
   //        WayPointManager.Getinstance().NodeNumber = NodeNumber;
   //
   //    }
   //}
    
      
        private void OnCollisionEnter(Collision collision)
        {
             int NodeNumber = WayPointManager.Getinstance().NodeNumber;
           
             if (collision.transform.tag == "Node" && Moving
                 && collision.transform.name == "Node " + NodeNumber)
                 {
                     Debug.Log("d");

                     NodeNumber = WayPointManager.Getinstance().NodeNumber;
                     int Tmp = WayPointManager.Getinstance().MaxNumber;
                     ++NodeNumber;
                     Moving = false;
                     if (NodeNumber > Tmp)
                     {
                         NodeNumber = 0;
                     }
                     WayPointManager.Getinstance().NodeNumber= NodeNumber;

                }

        }
     

   void Update()
   {
       if (Moving)
       {
           transform.Translate(Direction * Speed * Time.deltaTime);
  
           //transform.LookAt(Direction);
       }
       else
       {
           fTime = 2.0f;
           StartCoroutine("Behaviour");
       }
   }

   IEnumerator Behaviour()
   {
       yield return new WaitForSeconds(fTime);
       Direction = GetDirection();
   }
}
