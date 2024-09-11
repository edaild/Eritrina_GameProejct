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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PerformBasicAttack();
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

 
    private void PerformUltimateAttack()
    {
        Debug.Log("궁극기");
    }
}
