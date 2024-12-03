using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ ó���ϴ� ��ũ��Ʈ
public class EnemyAttack : MonoBehaviour
{
    public bool IsOnAttack = false;  // ���� ����
    public Playerhealthbarsystem playerhealthbar;  // �÷��̾��� ü���� �����ϴ� �ý���
    public EnemyData enemyData;  // ���� �����͸� �����ϴ� ����

    private void Start()
    {
        // Playerhealthbarsystem�� EnemyData�� ������ ã�� �Ҵ��մϴ�.
        playerhealthbar = FindObjectOfType<Playerhealthbarsystem>();

        // EnemyData�� �ν����Ϳ��� �Ҵ��ϰų�, ���⿡�� �ʱ�ȭ�ؾ� �մϴ�.
        if (enemyData == null)
        {
            Debug.LogError("EnemyData�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    private void Update()
    {
        // ���� ������ �� �÷��̾� ü���� ���ҽ�ŵ�ϴ�.
        if (IsOnAttack && playerhealthbar != null)
        {
            playerhealthbar.curHp -= enemyData.damage * Time.deltaTime;  // ���������� ü���� ����
            playerhealthbar.curHp = Mathf.Max(playerhealthbar.curHp, 0);  // ü���� 0���� ���� �ʵ��� ����
        }
    }

    // �÷��̾�� ���� ���� �� ���� ó��
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !IsOnAttack)  // �̹� ���� ���� �ƴϸ�
        {
            IsOnAttack = true;
            Debug.Log("�÷��̾�� ������. ���� ��...");
        }
    }

    // �÷��̾�� ���� ���� ��
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsOnAttack = false;
            Debug.Log("�÷��̾�� ���� ����");
        }
    }
}
