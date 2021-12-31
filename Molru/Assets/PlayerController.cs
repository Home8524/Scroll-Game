using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    private NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();    
    }
    void Update()
    {
        var Hor = Input.GetAxisRaw("Horizontal");
        var Ver = Input.GetAxisRaw("Vertical");

        transform.Translate(
            Hor * 5.0f * Time.deltaTime,
            0,
            Ver * 5.0f * Time.deltaTime);


        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit Hit;

            if (Physics.Raycast(ray,out Hit, Mathf.Infinity))
            {
                if(Hit.transform.tag == "Ground")
                {
                    Agent.SetDestination(Hit.point);
                }
            }
        }
    }
}
