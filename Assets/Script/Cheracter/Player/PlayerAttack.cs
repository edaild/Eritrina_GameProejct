using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attack_range; // 공격 범위
    public float attackN = 10f;     // 일반 공격 데미지
    public float attackS = 15f;     // 스킬 공격 데미지
    public float attackQ = 20f;     // 궁극기 공격 데미지

    public bool attackCheckS;       // 스킬 공격 상태
    public bool attackCheckQ;       // 궁극기 공격 상태
    public bool attackCheckN;       // 일반 공격 상태

    public Bullet bulletPrefab;     // 총알 프리팹
    public Transform shootPoint;    // 총알 발사 위치

    private void Start()
    {
        attack_range.gameObject.SetActive(false);  // 공격 범위 비활성화
    }

    private void Update()
    {
        HandleAttackInput();
    }

    // 입력에 따라 플레이어의 공격 처리
    private void HandleAttackInput()
    {
        // 기본 공격 (마우스 왼쪽 클릭)
        if (Input.GetMouseButtonDown(0))
        {
            PerformBasicAttack();
        }

        // 스킬 공격 (E 키)
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformSkillAttack();
        }

        // 궁극기 공격 (Q 키)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PerformUltimateAttack();
        }
    }

    // 기본 공격
    private void PerformBasicAttack()
    {
        attackCheckN = true;
        Debug.Log("일반 공격");
        FireBullet();  // 총알 발사
    }

    // 스킬 공격
    private void PerformSkillAttack()
    {
        attackCheckS = true;
        Debug.Log("스킬 공격");
        // 궁극기 관련 로직 작성

    }

    // 궁극기 공격
    private void PerformUltimateAttack()
    {
        attackCheckQ = true;
        Debug.Log("궁극기 공격");
        // 궁극기 관련 로직 작성
    }

    // 총알 발사 함수
    private void FireBullet()
    {
        // 총알 발사 위치 설정
        Bullet newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        newBullet.Firing();  // 총알 발사 메서드 호출
    }
}
