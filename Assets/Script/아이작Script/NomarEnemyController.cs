using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomarEnemyController : MonoBehaviour
{
    [Header("���� ����")]
    public float stoppingDistance = 2f; // �÷��̾�� �ּ� �Ÿ�
    public GameObject Enemy_attack_range; // ���� ����

    public Playerhealthbarsystem playerhealthbar;
    public EnemyData enemydata; // EnemyData�� ����

    private bool attackcheck; // ���� ó��
    public bool playercheck; // ����  ���

    private void Start()
    {
        // FindObjectOfType�� ��ü�� ã�� ������� ����
        playerhealthbar = FindObjectOfType<Playerhealthbarsystem>();

        // EnemyData�� �ν����Ϳ��� �Ҵ�� ���� ���
        if (enemydata == null)
        {
            Debug.LogError("EnemyData is not assigned! Please assign it in the inspector.");
        }
    }

    private void Update()
    {
        if (enemydata == null) return;  // enemydata�� �Ҵ���� ������ ��� �������� ����.

        // �÷��̾���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, playerhealthbar.Player.transform.position);

        // �÷��̾�� ����� ��쿡�� �ൿ
        if (playercheck)
        {
            if (distance > stoppingDistance)
            {
                // �÷��̾ �ٶ󺸰� �Ѵ�.
                Vector3 vector = playerhealthbar.Player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(vector);

                // �÷��̾� �������� �̵�
                Vector3 direction = (playerhealthbar.Player.transform.position - transform.position).normalized;
                transform.position += direction * enemydata.speed * Time.deltaTime;  // �ӵ� ����
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playercheck = true;
            Debug.Log("�÷��̾ check �Ǿ����ϴ�.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playercheck = false;
            Debug.Log("�÷��̾ ���� ���� �������ϴ�..");
        }
    }

    // �浹�� ���� ���� üũ
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ������ ���� ���� ����
            playerhealthbar.enemyattackcheck = true;
        }
        else
        {
            playerhealthbar.enemyattackcheck = false;
        }
    }
}
