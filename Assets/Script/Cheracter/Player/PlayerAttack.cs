using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 
    public GameObject attack_range; // 공격 범위
    public float attackN = 10;      // 일반 공격
    public float attackS = 15;      // 스킬 공격
    public float attackQ = 20;      // 궁극기 공격

    public bool attackCheckS;       // 스킬 공격
    public bool attackCheckQ;      // 궁극기 공격
    public bool attackCheckN;     // 일반 공격

    private void Start()
    {
        attack_range.gameObject.SetActive(false);
    }

    private void Update()
    {
        HandleAttackInput();
    }


    // 입력에 따라 플레이어의 공격 처리
    private void HandleAttackInput()
    {
        // 기본 공격 처리
        if (!Input.GetKeyDown(KeyCode.LeftAlt))
        {
             if (Input.GetMouseButtonDown(0))
        {
            PerformBasicAttack();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            attack_range.SetActive(false);
            attackCheckS = false;
        }
        // 스킬 공격 처리
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformSkillAttack();
        }
        // 긍극기 공격 처리
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Atick();
        }
        }
    }

    private void PerformBasicAttack()
    {
        Debug.Log("일반공격");
        attack_range.SetActive(true);
        attackCheckS = true;
    }


    private void PerformSkillAttack()
    {
        Debug.Log("스킬 공격");
    }

    private void Atick()
    {
        Debug.Log("긍극기 공격");
    }
}
