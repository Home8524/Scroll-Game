using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    private GameObject Target;

    private NavMeshAgent Agent;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Target = GameObject.Find("Player");
    }
    void Update()
    {
        var Distance = Vector3.Distance(transform.position,Target.transform.position);

        var Direction = (Target.transform.position - transform.position).normalized;


   

        if(Distance <= 20)
        {
            Agent.SetDestination(Target.transform.position);
        }
        else
        {
            Agent.enabled = false;
            //LookRotation =  Vec->Quat
          transform.rotation=  Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(Direction),
                Time.deltaTime * 1.0f);
            Agent.enabled = true;

        }

    }
}
