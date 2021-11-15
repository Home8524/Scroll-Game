using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InspectorEditer : MonoBehaviour ,IDragHandler, IPointerUpHandler , IPointerDownHandler
{
    /*
    [Header("Element")]
    [Tooltip("이동속도")]
    [SerializeField] private float Speed;
    [Tooltip("공격력")]
    [SerializeField] private float At;
    [Tooltip("방어력")]
    [SerializeField] private float Def;
    [Tooltip("체력")]
    [SerializeField] private float HP;
    [Tooltip("마력")]
    [Range(0,10)]
    [SerializeField] private float MP;
     */
    [Tooltip("움직일 대상")]
    [SerializeField] private Transform Target;

    [Tooltip("움직임을 제어할 스틱")]
    [SerializeField] private RectTransform Stick;

    [Tooltip("스틱의 뒷 배경")]
    [SerializeField] private RectTransform BackBoard;

    //스틱 뒷 배경의 반지름
    private float Radius = 0.0f;

    //터치 입력확인
    private bool TouchCheck = false;

    //이동 속도
    private float Speed = 0.0f;

    //방향
    private Vector2 Direction;

    //이동
    private Vector3 Movement;



    void Start()
    {
        //백보드의 반지름을 구함
        Radius = (BackBoard.rect.width/2.0f);
        Speed = 5.0f;
    }

    void Update()
    {
        if (TouchCheck)
            Target.position += Movement;
    }

    private void GetMovement(Vector2 _Point)
    {
        Stick.localPosition =  new Vector2(
        _Point.x- BackBoard.position.x,
            _Point.y- BackBoard.position.y
           );
        Stick.localPosition = Vector2.ClampMagnitude(Stick.localPosition,Radius);

        //내가 얼마만큼 움직일지 비율
        float Ratio = (BackBoard.position - Stick.position).sqrMagnitude / (Radius * Radius);

        Direction = Stick.localPosition.normalized;

        Movement = new Vector3(
            Direction.x*Speed*Ratio*Time.deltaTime,
            0,
            Direction.y * Speed * Ratio * Time.deltaTime
            );
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetMovement(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetMovement(eventData.position);
        TouchCheck = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Stick.localPosition = Vector3.zero;
        TouchCheck = false;
    }

    public void MyButton()
    {
        Debug.Log("MyButon");
    }
}
