using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeathBar : HealthBar
{
    public GameObject Enemy;
    public PlayerAttack playerAttack;
    private bool playerAttackCheck;

    public HealthBar HealthBar;

    void Start()
    {
        HealthBar = FindAnyObjectByType<HealthBar>();
        playerAttack = FindAnyObjectByType<PlayerAttack>();
    }

    void Update()
    {
        handleHp();
        PlayerAttackCheck();
        Die();
    }


    private void PlayerAttackCheck()
    {
        if (playerAttackCheck)
        {
            curHp -= playerAttack.attackN * Time.deltaTime; // 체력을 감소시키는 로직
        }
       
       
    }

    private void Die()
    {
        if (curHp <= 0)
        {
            curHp = 0; // 체력을 0으로 설정

            Enemy.gameObject.SetActive(false);
            Debug.Log("적 사망");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            // 적의 Hp를 감소한다.
            playerAttackCheck = true;
        }
        else
        {
            playerAttackCheck = false;
        }
    }
  
}
