using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAngle : MonoBehaviour
{
    public struct ViewCastInfo
    {
        public bool Hit;
        public Vector3 Point;
        public float Distance;
        public float Angle;

        public ViewCastInfo( bool _Hit, Vector3 _Point,float _Distance,float _Angle)
        {
            Hit = _Hit;
            Point = _Point;
            Distance = _Distance;
            Angle = _Angle;
        }
    }
    [Tooltip("시야 최대 거리")]
    public float Radius;

    [Tooltip("시야의 최대 각도")]
    [Range(0, 360)] public float Angle;

    [Tooltip("Target Layer Mask")]
    [SerializeField] private LayerMask TargetMask;

    [Tooltip("Obstacle Layer Mask")]
    [SerializeField] private LayerMask ObstacleMask;

    [Tooltip("Target List")]
    // [HideInInspector]
    public List<Transform> TargetList = new List<Transform>();

    [Tooltip("시야각의 라인 개수")]
    private int LineAngle = 1;


    Mesh ViewMesh;
    public MeshFilter ViewMeshFilter =null;
    private void Start()
    {
        ViewMesh = new Mesh();
        ViewMesh.name = "View Mesh";
        ViewMeshFilter.mesh = ViewMesh;
        Radius = 25.0f;
        Angle = 95.0f;
        LineAngle = 1;
    }

    private void Update()
    {
        TargetList.Clear();
        //Collider[] OverlapSphere(Vector3 position, float radius, int layerMask);
        Collider[] InTargets = Physics.OverlapSphere(transform.position, Radius, TargetMask);

        for (int i = 0; i < InTargets.Length; ++i)
        {
            Transform Target = InTargets[i].transform;

            Vector3 TargetDirection = (Target.position - transform.position).normalized;

            float TargetDistance = Vector3.Distance(transform.position, Target.position);

            if (Vector3.Angle(transform.forward, TargetDirection) < Angle / 2)
            {
                if (!Physics.Raycast(transform.position, TargetDirection, TargetDistance, ObstacleMask))
                {
                    TargetList.Add(Target);
                }
            }
        }
    }
    private void LateUpdate()
    {
        ViewMesh.Clear();
        // Mathf.RoundToInt 데이터가 소수로 나올 때 근접한 정수를 찾아줌
        // Angle = 95 , LineAgle = 1
        // LineCount = 95/1
        int LineCount = Mathf.RoundToInt(Angle / LineAngle);

        // 95/95 =1
        float AngleSize = (Angle / LineCount);

        //Vertex를 담을 List
        List<Vector3> ViewPointList = new List<Vector3>();

        //ViewPointList 확인
        for(int i=0; i<LineCount; ++i)
        {
            float ViewAngle = transform.eulerAngles.y + (Angle / 2) + AngleSize*i;

            ViewCastInfo tViewCast = ViewCast(ViewAngle);

            ViewPointList.Add(tViewCast.Point);
        }

        //모든 Vertex의 개수를 확인
        int VertexCount = ViewPointList.Count + 1;

        //95+1 개가 만들어짐
        Vector3[] VertexList = new Vector3[VertexCount];
        VertexList[0] = Vector3.zero;


        //삼각형을 만드는데 드는 순열 개수 = (AllVertex-2)*3
        //(96-2)*3 = 282
        int[] Triangles = new int[(VertexCount-2)*3];

        for(int i = 0; i < VertexCount - 1; ++i)
        {
            //로컬좌표 = Transform.InverseTransformPoint(월드좌표)
            VertexList[i + 1] = transform.InverseTransformPoint(ViewPointList[i]);

            if(i< VertexCount-2)
            {
                Triangles[i * 3] = 0;
                Triangles[i * 3 + 1] = i+1;
                Triangles[i * 3 + 2] = i+2;
            }
        }

        ViewMesh.vertices = VertexList;
        ViewMesh.triangles = Triangles;

        //삼각형 그리기용
        ViewMesh.RecalculateNormals();

    }


    
     public Vector3 LocalViewAngle(float _Angle)
       {
        _Angle += transform.eulerAngles.y;
        //라디안 = 180 / 3.14  , angle/180*3.141592
        //각 = 3.14/180 
        return new Vector3(
                Mathf.Sin(_Angle *Mathf.Deg2Rad),
                0.0f,
                Mathf.Cos(_Angle * Mathf.Deg2Rad));
       }
     
    public Vector3 DirectionViewAngle(float _Angle)
    {
        return new Vector3(
            Mathf.Sin(_Angle * Mathf.Deg2Rad),
            0.0f,
            Mathf.Cos(_Angle * Mathf.Deg2Rad));
    }

    public ViewCastInfo ViewCast(float _Angle)
    {
        Vector3 Direction = DirectionViewAngle(_Angle);

        RaycastHit Hit;

        if(Physics.Raycast(transform.position,Direction,out Hit,Radius,ObstacleMask))
        {
            return new ViewCastInfo(true, Hit.point,Hit.distance,_Angle);
        }
        return new ViewCastInfo(false,transform.position+Direction*Radius,Radius,_Angle);
    }
}
