using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealthbarsystem : HealthBar
{
    [Header("playerCharacterList")]


    public GameObject DieImage;    // 게임 오버 이미지
    public GameObject Player; // 플레이어
    public Text curHpText;

    private bool enemyattackcheck;
    private float attackDamage = 5f; // 공격에 의해 감소하는 체력

    public HealthBar HealthBar;

    private void Start()
    {
        HealthBar = FindAnyObjectByType<HealthBar>();
    }

    private void Update()
    {
        handleHp();
        Enemyattackcheck();
        Die();
    }


    private void Enemyattackcheck()
    {
        if (enemyattackcheck)
        {
            curHp -= attackDamage * Time.deltaTime; // 체력을 감소시키는 로직
        }
    }

    private void Die()
    {
        if (curHp <= 0)
        {
            curHp = 0; // 체력을 0으로 설정

            DieImage.SetActive(true);
            Player.gameObject.SetActive(false);
        }
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        enemyattackcheck = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        enemyattackcheck = false;
    //    }
    //}
}
