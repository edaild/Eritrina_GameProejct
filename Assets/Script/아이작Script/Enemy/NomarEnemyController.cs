using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // NavMeshAgent ���� ���ӽ����̽� �߰�
using UnityEngine.UI;

public class NomarEnemyController : MonoBehaviour
{
    [Header("���� ����")]
    public float stoppingDistance = 2f; // �÷��̾�� �ּ� �Ÿ�
    public GameObject Enemy_attack_range; // ���� ����

    public Playerhealthbarsystem playerhealthbar;
    public EnemyData enemydata; // EnemyData�� ����

    public GameObject startText;
    private bool attackcheck; // ���� ó��
    public bool playercheck; // ���� ���

    private NavMeshAgent navMeshAgent; // NavMeshAgent�� ���� ���� �߰�

    private void Start()
    {
        playerhealthbar = FindObjectOfType<Playerhealthbarsystem>();
        navMeshAgent = GetComponent<NavMeshAgent>(); // NavMeshAgent ������Ʈ ��������
        if (navMeshAgent != null)
        {
            navMeshAgent.stoppingDistance = stoppingDistance; // NavMeshAgent�� stoppingDistance ����
        }
    }

    private void Update()
    {
        if (enemydata == null || navMeshAgent == null) return;

        // �÷��̾���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, playerhealthbar.Player.transform.position);

        // �÷��̾�� ����� ��쿡�� �ൿ
        if (playercheck)
        {
            // �÷��̾ �ʹ� �ָ� ������ ����
            if (distance > stoppingDistance)
            {
                // �÷��̾ �ٶ󺸰� �Ѵ�.
                Vector3 vector = playerhealthbar.Player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(vector);

                // �÷��̾� �������� �̵�
                navMeshAgent.SetDestination(playerhealthbar.Player.transform.position); // NavMeshAgent�� ����Ͽ� ��� ����
            }
            else
            {
                // ���� �÷��̾�� ���� �Ÿ� ���� ������ ����
                navMeshAgent.ResetPath();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerhealthbar.enemyattackcheck = true;

            if (startText != null)
            {
                Destroy(startText);
            }
        }
        else
        {
            playerhealthbar.enemyattackcheck = false;
        }
    }
}
