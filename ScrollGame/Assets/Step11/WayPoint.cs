using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Vector2 Radius;

    private Vector2 PointA;
    private Vector2 PointB;

    [SerializeField] private int WayPointCount;
    [SerializeField] private GameObject WayPointPrefab;
   [SerializeField] private GameObject Enemy;
    [SerializeField] private int NodeNumber;
    [HideInInspector] public List<GameObject> WayPointList = new List<GameObject>();

    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/Step11/WayPointPrefab") as GameObject;
    }


    void Start()
    {
        StartCoroutine("CreateEnemy");
        NodeNumber = 0;
        WayPointCount = 5;
        PointA = new Vector2(transform.position.x- Radius.x, transform.position.z + Radius.y);
        PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        WayPointManager.GetInstance().PointA = PointA;
        WayPointManager.GetInstance().PointB = PointB;

        for (int i=0;i<WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointPrefab);

            Obj.AddComponent<Rigidbody>();

            Obj.AddComponent<BoxCollider>();
            Obj.AddComponent<Test>();
            Obj.transform.position = new Vector3(
                Random.Range(
                    WayPointManager.GetInstance().PointA.x,
                    WayPointManager.GetInstance().PointB.x),
                    5.0f,
                Random.Range(
                    WayPointManager.GetInstance().PointA.y,
                    WayPointManager.GetInstance().PointB.y));
            Obj.transform.name = "WayPointPrefab" + i;
            Obj.transform.parent = transform;

            WayPointList.Add(Obj);
            
        }
        NodeNumber = WayPointManager.GetInstance().NodeNumber;

        WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;

    }
    private void LateUpdate()
    {
        NodeNumber = WayPointManager.GetInstance().NodeNumber;

        WayPointManager.GetInstance().TargetPoint 
            = WayPointList[NodeNumber].transform.position;
    }
    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(5.0f);


        Enemy = Instantiate(WayPointManager.GetInstance().EnemyPrefab);
        Enemy.transform.transform.position = transform.position;

    }

}
