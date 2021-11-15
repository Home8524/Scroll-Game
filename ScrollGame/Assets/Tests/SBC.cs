using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBC : MonoBehaviour
{
    void Start()
    {
        GameObject Player = GameObject.Find("Shooter");
        Vector3 Player2 = Player.transform.rotation.eulerAngles;

        float tmp = Player2.x;
        float tmp2 = Player2.y;
        if (tmp2 > 180) tmp2 = 180.0f - (tmp2 - 180.0f);
        float z = tmp2;
        float x = 180.0f - tmp2;
        Debug.Log(x);
        Debug.Log(z);
        this.gameObject.GetComponent<Rigidbody>().AddForce(90,tmp,90);
    }
    private void OnEnable()
    {
        GameObject Player = GameObject.Find("Shooter");
        Vector3 Player2 = Player.transform.rotation.eulerAngles;

        float tmp = Player2.x;
        float tmp2 = Player2.y;
        if (tmp2 > 180) tmp2 = 180.0f - (tmp2 - 180.0f);
        float z = tmp2;
        float x = 180.0f - tmp2;
        this.gameObject.GetComponent<Rigidbody>().AddForce(90, tmp, 90);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            ObjectManager.Getinstance().GetEnableList.Remove(this.gameObject);
            this.gameObject.SetActive(false);
            ObjectManager.Getinstance().GetDisableList.Push(this.gameObject);
        }

    }
}
