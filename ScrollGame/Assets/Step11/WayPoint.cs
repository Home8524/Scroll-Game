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
    
    public List<GameObject> WayPointList = new List<GameObject>();
    
    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/Step11/WayPointPrefab") as GameObject;

    }


    void Start()
    {
        WayPointCount = 5;
        PointA = new Vector2(transform.position.x- Radius.x, transform.position.z + Radius.y);
        PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);


        for (int i=0;i<WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointPrefab);

            Obj.AddComponent<Rigidbody>();

            Obj.AddComponent<SphereCollider>();
            Obj.AddComponent<Test>();
            Obj.transform.position = new Vector3(Random.Range(PointA.x,PointB.x),5.0f, Random.Range(PointA.y, PointB.y));
            Obj.transform.name = "WayPointPrefab" + i;
          
            WayPointList.Add(Obj);
            
        }
    }

    void Update()
    {
        
    }


}
