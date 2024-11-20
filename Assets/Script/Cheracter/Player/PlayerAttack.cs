using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attack_range; // ���� ����
    public float attackN = 10f;     // �Ϲ� ���� ������
    public float attackS = 15f;     // ��ų ���� ������
    public float attackQ = 20f;     // �ñر� ���� ������

    public bool attackCheckS;       // ��ų ���� ����
    public bool attackCheckQ;       // �ñر� ���� ����
    public bool attackCheckN;       // �Ϲ� ���� ����

    public Bullet bulletPrefab;     // �Ѿ� ������
    public Transform shootPoint;    // �Ѿ� �߻� ��ġ

    private void Start()
    {
        attack_range.gameObject.SetActive(false);  // ���� ���� ��Ȱ��ȭ
    }

    private void Update()
    {
        HandleAttackInput();
    }

    // �Է¿� ���� �÷��̾��� ���� ó��
    private void HandleAttackInput()
    {
        // �⺻ ���� (���콺 ���� Ŭ��)
        if (Input.GetMouseButtonDown(0))
        {
            PerformBasicAttack();
        }

        // ��ų ���� (E Ű)
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformSkillAttack();
        }

        // �ñر� ���� (Q Ű)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PerformUltimateAttack();
        }
    }

    // �⺻ ����
    private void PerformBasicAttack()
    {
        attackCheckN = true;
        Debug.Log("�Ϲ� ����");
        FireBullet();  // �Ѿ� �߻�
    }

    // ��ų ����
    private void PerformSkillAttack()
    {
        attackCheckS = true;
        Debug.Log("��ų ����");
        // �ñر� ���� ���� �ۼ�

    }

    // �ñر� ����
    private void PerformUltimateAttack()
    {
        attackCheckQ = true;
        Debug.Log("�ñر� ����");
        // �ñر� ���� ���� �ۼ�
    }

    // �Ѿ� �߻� �Լ�
    private void FireBullet()
    {
        // �Ѿ� �߻� ��ġ ����
        Bullet newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        newBullet.Firing();  // �Ѿ� �߻� �޼��� ȣ��
    }
}
