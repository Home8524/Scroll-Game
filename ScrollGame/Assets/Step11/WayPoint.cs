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
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int NodeNumber;
    [HideInInspector] public List<GameObject> WayPointList = new List<GameObject>();

    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/Step11/WayPointPrefab") as GameObject;
        EnemyPrefab = Resources.Load("Prefabs/Step11/Enemy") as GameObject;
    }


    void Start()
    {
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
    }
    private void Update()
    {
        //WayPointList[NodeNumber];


        if(NodeNumber > (WayPointList.Count -1))
        {

        }
    }


}
