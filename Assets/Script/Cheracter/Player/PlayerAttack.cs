using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 
    private void Update()
    {
        HandleAttackInput();
    }


    // �Է¿� ���� �÷��̾��� ���� ó��
    private void HandleAttackInput()
    {
        // �⺻ ���� ó��
        if (Input.GetMouseButtonDown(0))
        {
            PerformBasicAttack();
        }
        // ��ų ���� ó��
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformSkillAttack();
        }
        // ��ر� ���� ó��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Atick();
        }
    }

    private void PerformBasicAttack()
    {
        Debug.Log("�Ϲݰ���");
    }


    private void PerformSkillAttack()
    {
        Debug.Log("��ų ����");
    }

    private void Atick()
    {
        Debug.Log("��ر� ����");
    }
}