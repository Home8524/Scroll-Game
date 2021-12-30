using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator Anim;

    private bool Skill;
    private float SkillTime;
    private bool Attack;

    //private Queue<bool> CombinationList;
    private bool Combination;
    private float CombinationTime;

    private void Awake()
    {
        Anim = transform.GetComponent<Animator>();
    }

    private void Start()
    {
        Attack = false;
        Skill = false;
        SkillTime = 5.0f;
        CombinationTime = 0.4f;
        Combination = false;
    }
    void Update()
    {
        var Ver = Input.GetAxis("Vertical");

        if(!Attack)
        {
            if (Input.GetKey(KeyCode.LeftShift) && !Skill)
            {
                Skill = true;
                StartCoroutine("PlayerRun");
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl))
                    Ver /= 2;
            }

            if (Skill)
                Ver = 2.0f;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Combination = true;
                Anim.SetBool("Combination", true);
                StartCoroutine("SetCombination");
            }
        }
        
        Anim.SetFloat("Speed", Ver);
    }
    private void LateUpdate()
    {
        Anim.SetBool("Attack", Attack);
    }
    IEnumerator SetCombination()
    {
        while(Combination)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            CombinationTime -= Time.deltaTime;
            if (Input.GetMouseButtonDown(0))
            {
                Anim.SetTrigger("NextCombination");
                CombinationTime = 0.4f;
            }
            if (CombinationTime <= 0)
                break;
        }
        Combination = false;
        Anim.SetBool("Combination", false);
        CombinationTime = 0.4f;
    }
    IEnumerator PlayerRun()
    {
        while(Skill)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            SkillTime -= Time.deltaTime;
            if (SkillTime <= 0)
                break;
        }
        Skill = false;
        SkillTime = 5.0f;
    }

    public void SetAttackMotion()
    {
        Attack = !Attack;
    }
}
