using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerAttack PlayerAttack;

    private void Start()
    {
        PlayerAttack = FindAnyObjectByType<PlayerAttack>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어가 적에게 일반공격을 성공해습니다.");
            PlayerAttack.attackCheckN = true;
        }
    }
}

