using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRotation : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        //* Vector.up �������� ��Ÿ���� vector 
        //* Vector.up�� �������� 0.5f��ŭ ȸ�� ��Ŵ
        //this.transform.Rotate(vector3.up,0.5f);

        //* Vector�� �������� ȸ��, (x,y,z)�� ���� �ۼ���
        //this.transform.Rotate(0.0f, Time.deltaTime, 0.0f);

        //*Space.Self = ������ǥ�� �������� ȸ��
        //*Space.World = �۷ι� ��ǥ�� �������� ȸ��
        //this.transform.Rotate(0.0f, Time.deltaTime*0.2f,Space.Self);

        //* Key �Է��� �޾� ȸ����Ű�� �ڵ带 �ۼ��� ����
        float Hor = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0.0f, Hor * Time.deltaTime * 5.0f, 0.0f);

    }
}
