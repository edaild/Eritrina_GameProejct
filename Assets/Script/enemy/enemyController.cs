using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // 몬스터 health

    [Header("몬스터 설정")]
    public float enemySpeed = 3f; // 몬스터 이동 속도
    public Transform player; //타겟 플레이어
    public float stoppingDistance = 2f; // 플레이어와 최소 거리

    private bool playercheck;

    private void Update()
    {
        // 플레이어와의 거리 계산
        float distance = Vector3.Distance(transform.position, player.position);

        if (playercheck)
        {
            if (distance > stoppingDistance)
            {
                // 플레이어 방향으로 이동
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * enemySpeed * Time.deltaTime;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어가 check 되었습니다.");
            playercheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playercheck = false;
    }
}


