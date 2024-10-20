using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // ���� health

    [Header("���� ����")]
    [Tooltip("���� �̵� �ӵ�")] public float enemySpeed = 3f;
    [Tooltip("�÷��̾�")] public Transform player;
    [Tooltip("�÷��̾���� �ּ� �Ÿ�")] public float stoppingDistance = 2f;

    private bool playercheck;

    private void Update()
    {
        // �÷��̾���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, player.position);

        if (playercheck)
        {
            if (distance > stoppingDistance)
            {
                // �÷��̾� �������� �̵�
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * enemySpeed * Time.deltaTime;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ check �Ǿ����ϴ�.");
            playercheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playercheck = false;
    }
}

