using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyController : MonoBehaviour
{
    // ���� health

    [Header("���� ����")]
    public float enemySpeed = 3f; // ���� �̵� �ӵ�
    public Transform player; //Ÿ�� �÷��̾�
    public float stoppingDistance = 2f; // �÷��̾�� �ּ� �Ÿ�
    public GameObject Enemy_attack_range; // ���� ����

    private bool attackcheck; // ���� ó��
    private bool playercheck; // ���� ����

    private void Update()
    {
        // �÷��̾���� �Ÿ� ���
        float distance = Vector3.Distance(transform.position, player.position);



        if (playercheck)
        {
            if (distance > stoppingDistance)
            {
                // �÷��̾ �ٶ󺸰� �Ѵ�.
                Vector3 vector = player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(vector).normalized;
                transform.LookAt(player);

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
}


