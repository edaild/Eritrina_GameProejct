using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealthbarsystem : HealthBar
{
    [Header("playerCharacterList")]


    public GameObject DieImage;    // ���� ���� �̹���
    public GameObject Player; // �÷��̾�
    public Text curHpText;

    private bool enemyattackcheck;
    private float attackDamage = 5f; // ���ݿ� ���� �����ϴ� ü��

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
            curHp -= attackDamage * Time.deltaTime; // ü���� ���ҽ�Ű�� ����
        }
    }

    private void Die()
    {
        if (curHp <= 0)
        {
            curHp = 0; // ü���� 0���� ����

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
