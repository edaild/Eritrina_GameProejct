using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 
    private void Update()
    {
        HandleAttackInput();
    }


    // 입력에 따라 플레이어의 공격 처리
    private void HandleAttackInput()
    {
        // 기본 공격 처리
        if (Input.GetMouseButtonDown(0))
        {
            PerformBasicAttack();
        }
        // 스킬 공격 처리
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformSkillAttack();
        }
    }

    private void PerformBasicAttack()
    {
        Debug.Log("일반공격");
    }


    private void PerformSkillAttack()
    {
        Debug.Log("스킬 공격");
    }

}
