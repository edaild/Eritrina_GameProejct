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
            curHp -= playerAttack.attackN * Time.deltaTime; 
        }


    }

    private void Die()
    {
        if (curHp <= 0)
        {
            curHp = 0; 

            Enemy.gameObject.SetActive(false);
            Debug.Log("�� ���");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
   
            playerAttackCheck = true;
        }
        else
        {
            playerAttackCheck = false;
        }
    }

}