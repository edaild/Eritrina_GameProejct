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
  //  public Transform player; //Ÿ�� �÷��̾�
    public float stoppingDistance = 2f; // �÷��̾�� �ּ� �Ÿ�
    public GameObject Enemy_attack_range; // ���� ����

    public Playerhealthbarsystem playerhealthbar;

    private bool attackcheck; // ���� ó��
    private bool playercheck; // ���� ����

    private void Start()
    {
        playerhealthbar = FindAnyObjectByType<Playerhealthbarsystem>();
    }
    private void Update()
    {

        // �÷��̾���� �Ÿ� ���
        //float distance = Vector3.Distance(transform.position, playerhealthbar.Player.transform.position);



        if (playercheck)
        {
            //if (distance > stoppingDistance)
            {
                // �÷��̾ �ٶ󺸰� �Ѵ�.
                Vector3 vector = playerhealthbar.Player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(vector).normalized;
                transform.LookAt(playerhealthbar.Player.transform.position);

                // �÷��̾� �������� �̵�
                Vector3 direction = (playerhealthbar.Player.transform.position - transform.position).normalized;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
            playerhealthbar.enemyattackcheck = true;
        else playerhealthbar.enemyattackcheck = false;
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


