using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ ����� �¾� ������
[CreateAssetMenu(menuName = "Scriptable/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public float MaxHealth;     // �ִ� ü��
    public float CurHealth;    // ���� ü��
    public float speed;     // �ӵ�
    public float damage;    // ���ݷ�

}
