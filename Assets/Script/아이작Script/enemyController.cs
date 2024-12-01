using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyController : MonoBehaviour
{
    // 몬스터 health

    [Header("몬스터 설정")]
    public float enemySpeed = 3f; // 몬스터 이동 속도
  //  public Transform player; //타겟 플레이어
    public float stoppingDistance = 2f; // 플레이어와 최소 거리
    public GameObject Enemy_attack_range; // 공격 범위

    public Playerhealthbarsystem playerhealthbar;

    private bool attackcheck; // 공격 처리
    private bool playercheck; // 공격 범위

    private void Start()
    {
        playerhealthbar = FindAnyObjectByType<Playerhealthbarsystem>();
    }
    private void Update()
    {

        // 플레이어와의 거리 계산
        //float distance = Vector3.Distance(transform.position, playerhealthbar.Player.transform.position);



        if (playercheck)
        {
            //if (distance > stoppingDistance)
            {
                // 플레이어를 바라보게 한다.
                Vector3 vector = playerhealthbar.Player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(vector).normalized;
                transform.LookAt(playerhealthbar.Player.transform.position);

                // 플레이어 방향으로 이동
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
            Debug.Log("플레이어가 check 되었습니다.");
         
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
            Debug.Log("플레이어가 범위 내를 나갔습니다..");

        }
    }
}


