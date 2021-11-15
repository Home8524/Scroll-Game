using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRotation : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        //* Vector.up 기준축을 나타내는 vector 
        //* Vector.up을 기준으로 0.5f만큼 회전 시킴
        //this.transform.Rotate(vector3.up,0.5f);

        //* Vector를 기준으로 회전, (x,y,z)를 직접 작성함
        //this.transform.Rotate(0.0f, Time.deltaTime, 0.0f);

        //*Space.Self = 로컬좌표를 기준으로 회전
        //*Space.World = 글로벌 좌표를 기준으로 회전
        //this.transform.Rotate(0.0f, Time.deltaTime*0.2f,Space.Self);

        //* Key 입력을 받아 회전시키는 코드를 작성해 보자
        float Hor = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0.0f, Hor * Time.deltaTime * 5.0f, 0.0f);

    }
}
