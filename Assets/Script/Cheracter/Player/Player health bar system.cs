using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealthbarsystem : MonoBehaviour
{
    [Header("playerCharacterList")]
    public GameObject[] playerCharacterList = new GameObject[4]; // 플레이어 배열

    public GameObject DieImage;    // 게임 오버 이미지
    public GameObject Player; // 플레이어
    public Text curHpText;

    [SerializeField]
    private Slider healthBar;
    [Tooltip("최대값")] private float MaxHp = 100;
    [Tooltip("최소값")] private float curHp = 100;

    private bool enemyattackcheck;
    private float attackDamage = 10f; // 공격에 의해 감소하는 체력

    private void Start()
    {
        healthBar.value = curHp / MaxHp;
    }

    private void Update()
    {
        CurHpText();
        handleHp();
        Enemyattackcheck();
        Die();
    }

    private void CurHpText() 
    {
        // 현제 체력 출력
        curHpText.text = Mathf.FloorToInt(curHp) + " / " + Mathf.FloorToInt(MaxHp);
    }

    private void handleHp()
    {
        healthBar.value = Mathf.Lerp(healthBar.value, curHp / MaxHp, Time.deltaTime * 10);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyattackcheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyattackcheck = false;
        }
    }
}
