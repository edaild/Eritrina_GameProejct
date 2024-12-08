using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomarEnemyController : MonoBehaviour
{
    [Header("몬스터 설정")]
    public float stoppingDistance = 2f; // 플레이어와 최소 거리
    public GameObject Enemy_attack_range; // 공격 범위

    public Playerhealthbarsystem playerhealthbar;
    public EnemyData enemydata; // EnemyData를 참조

    public GameObject startText;
    private bool attackcheck; // 공격 처리
    public bool playercheck; // 공격  대상

    private void Start()
    {
       
        playerhealthbar = FindObjectOfType<Playerhealthbarsystem>();  
    }

    private void Update()
    {
        if (enemydata == null) return;  

        // 플레이어와의 거리 계산
        float distance = Vector3.Distance(transform.position, playerhealthbar.Player.transform.position);

        // 플레이어와 가까운 경우에만 행동
        if (playercheck)
        {
            if (distance > stoppingDistance)
            {
                // 플레이어를 바라보게 한다.
                Vector3 vector = playerhealthbar.Player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(vector);

                // 플레이어 방향으로 이동
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
            Debug.Log("플레이어가 check 되었습니다.");
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
