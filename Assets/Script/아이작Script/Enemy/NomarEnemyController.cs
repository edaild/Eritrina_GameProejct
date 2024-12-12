using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // NavMeshAgent 관련 네임스페이스 추가
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
    public bool playercheck; // 공격 대상

    private NavMeshAgent navMeshAgent; // NavMeshAgent를 위한 변수 추가

    private void Start()
    {
        playerhealthbar = FindObjectOfType<Playerhealthbarsystem>();
        navMeshAgent = GetComponent<NavMeshAgent>(); // NavMeshAgent 컴포넌트 가져오기
        if (navMeshAgent != null)
        {
            navMeshAgent.stoppingDistance = stoppingDistance; // NavMeshAgent의 stoppingDistance 설정
        }
    }

    private void Update()
    {
        if (enemydata == null || navMeshAgent == null) return;

        // 플레이어와의 거리 계산
        float distance = Vector3.Distance(transform.position, playerhealthbar.Player.transform.position);

        // 플레이어와 가까운 경우에만 행동
        if (playercheck)
        {
            // 플레이어가 너무 멀리 있으면 추적
            if (distance > stoppingDistance)
            {
                // 플레이어를 바라보게 한다.
                Vector3 vector = playerhealthbar.Player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(vector);

                // 플레이어 방향으로 이동
                navMeshAgent.SetDestination(playerhealthbar.Player.transform.position); // NavMeshAgent를 사용하여 경로 설정
            }
            else
            {
                // 적이 플레이어와 일정 거리 내에 들어오면 멈춤
                navMeshAgent.ResetPath();
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
