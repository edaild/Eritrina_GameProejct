using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;  // 적 객체를 GameObject로 참조
    public PlayerAttack playerAttack;  // PlayerAttack 스크립트
    public float speed = 10f;  // 총알 속도

    private void Start()
    {
        // PlayerAttack이 null인 경우를 방지하는 null 체크
        if (playerAttack == null)
        {
            playerAttack = FindObjectOfType<PlayerAttack>();  // PlayerAttack 스크립트 찾아 할당
        }

        // enemy가 null일 경우 찾아주는 코드 추가
        if (enemy == null)
        {
            Debug.LogWarning("Enemy 객체가 할당되지 않았습니다. 적을 할당해 주세요.");
        }
    }

    private void Update()
    {
        if (enemy != null)
        {
            // 적 방향으로 회전
            Vector3 direction = enemy.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);  // 회전 부드럽게

            // 총알을 적 방향으로 이동
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);  // 로컬 좌표계 기준 이동
        }
    }

    // 총알 발사 함수
    public void Firing()
    {
        gameObject.SetActive(true);  // 총알을 활성화
    }

    // 충돌 처리
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // 적과 충돌 시
        {
            Debug.Log("플레이어가 적에게 일반 공격을 성공했습니다.");
            if (playerAttack != null)
            {
                playerAttack.attackCheckN = true;  // 공격 체크
            }
            gameObject.SetActive(false);  // 총알 비활성화
        }
    }
}
