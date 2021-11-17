using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Tooltip("시야 최대 거리")]
    public float Radius;
    
    [Tooltip("시야의 최대 각도")]
    [Range(0,360)]public float Angle;

    [Tooltip("Target Layer Mask")]
    [SerializeField] private LayerMask TargetMask;

    [Tooltip("Obstacle Layer Mask")]
    [SerializeField] private LayerMask ObstacleMask;

    [Tooltip("Target List")]
   // [HideInInspector]
    public List<Transform> TargetList = new List<Transform>();

    private void Start()
    {
        Radius = 25.0f;
        Angle = 95.0f;
    }

    private void Update()
    {
        TargetList.Clear();
        //Collider[] OverlapSphere(Vector3 position, float radius, int layerMask);
        Collider[] InTargets = Physics.OverlapSphere(transform.position,Radius,TargetMask); 

        for(int i=0;i<InTargets.Length;++i)
        {
            Transform Target = InTargets[i].transform;

            Vector3 TargetDirection = Target.position - transform.position.normalized;

            if(Vector3.Angle(transform.forward,TargetDirection)<Angle/2)
            {
                float TargetDistance = Vector3.Distance(transform.position,Target.position);

                if(Physics.Raycast(transform.position,TargetDirection,TargetDistance,ObstacleMask))
                {
                    TargetList.Add(Target);
                }

            }
        }
    }

}
