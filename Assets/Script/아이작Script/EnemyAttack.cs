using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적의 공격을 처리하는 스크립트
public class EnemyAttack : MonoBehaviour
{
    public bool IsOnAttack = false;  // 공격 여부
    public Playerhealthbarsystem playerhealthbar;  // 플레이어의 체력을 관리하는 시스템
    public EnemyData enemyData;  // 적의 데이터를 저장하는 변수

    private void Start()
    {
        // Playerhealthbarsystem과 EnemyData를 씬에서 찾아 할당합니다.
        playerhealthbar = FindObjectOfType<Playerhealthbarsystem>();

        // EnemyData는 인스펙터에서 할당하거나, 여기에서 초기화해야 합니다.
        if (enemyData == null)
        {
            Debug.LogError("EnemyData가 할당되지 않았습니다!");
        }
    }

    private void Update()
    {
        // 공격 상태일 때 플레이어 체력을 감소시킵니다.
        if (IsOnAttack && playerhealthbar != null)
        {
            playerhealthbar.curHp -= enemyData.damage * Time.deltaTime;  // 지속적으로 체력을 감소
            playerhealthbar.curHp = Mathf.Max(playerhealthbar.curHp, 0);  // 체력이 0보다 작지 않도록 제한
        }
    }

    // 플레이어와 접촉 중일 때 공격 처리
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !IsOnAttack)  // 이미 공격 중이 아니면
        {
            IsOnAttack = true;
            Debug.Log("플레이어와 접촉중. 공격 중...");
        }
    }

    // 플레이어와 접촉 종료 시
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsOnAttack = false;
            Debug.Log("플레이어와 접촉 종료");
        }
    }
}
