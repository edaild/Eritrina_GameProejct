using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 좀비 생성시 사용할 셋업 데이터
[CreateAssetMenu(menuName = "Scriptable/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public float MaxHealth;     // 최대 체력
    public float CurHealth;    // 현재 체력
    public float speed;     // 속도
    public float damage;    // 공격력

}
