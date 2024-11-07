using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 
    public GameObject attack_range; // ���� ����
    public float attackN = 10;      // �Ϲ� ����
    public float attackS = 15;      // ��ų ����
    public float attackQ = 20;      // �ñر� ����

    public bool attackCheckS;       // ��ų ����
    public bool attackCheckQ;      // �ñر� ����
    public bool attackCheckN;     // �Ϲ� ����

    private void Start()
    {
        attack_range.gameObject.SetActive(false);
    }

    private void Update()
    {
        HandleAttackInput();
    }


    // �Է¿� ���� �÷��̾��� ���� ó��
    private void HandleAttackInput()
    {
        // �⺻ ���� ó��
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
    }

    private void PerformBasicAttack()
    {
        Debug.Log("�Ϲݰ���");
        attack_range.SetActive(true);
        attackCheckS = true;
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
