using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    [SerializeField]private bool Moving = false;
    [SerializeField] private GameObject ParentObj;
    [SerializeField] private Node TargetNode = null;

    private void Awake()
    {
        ParentObj = GameObject.Find("Parent");
    }


    private void Start()
    {
        Rigidbody Rigid = transform.GetComponent<Rigidbody>();

        Rigid.useGravity = false;

        CapsuleCollider Coll = transform.GetComponent<CapsuleCollider>();

        Coll.center = new Vector3(0.0f, 0.0f, 0.0f);
        Coll.height = 2.0f;

        Coll.isTrigger = true;

        StartCoroutine("NodeChecking");
    }
    private void Update()
    {
        if(Moving)
        {
            Vector3 Direction = (TargetNode.transform.position
                - transform.position).normalized;

            transform.position += Direction * 1.5f * Time.deltaTime;

            transform.LookAt(TargetNode.transform);

            Debug.DrawLine(this.transform.position, TargetNode.transform.position
                , Color.red);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (TargetNode && other.transform.name == ("Node " + TargetNode.Index))
            TargetNode = TargetNode.NextNode;
    }
    IEnumerator NodeChecking()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            if(ParentObj.transform.childCount>1)
            {
                TargetNode = ParentObj.transform.GetChild(0).GetComponent<Node>();

                Moving = true;

                break;
            }
        }
    }
}
