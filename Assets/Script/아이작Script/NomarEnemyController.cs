using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public bool playercheck; // ����  ���

    private void Start()
    {
       
        playerhealthbar = FindObjectOfType<Playerhealthbarsystem>();  
    }

    private void Update()
    {
        if (enemydata == null) return;  

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
                transform.position += direction * enemydata.speed * Time.deltaTime;
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
            
            if (startText == true)
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
