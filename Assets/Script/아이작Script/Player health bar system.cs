using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;

public class Playerhealthbarsystem : HealthBar
{
    public GameObject cube;         // 재시작 시 플레이어 재생성 위치
    public GameObject DieImage;    // 게임 오버 이미지
    public GameObject Player;       // 플레이어
    public Text curHpText;

    public bool enemyattackcheck;
    private float attackDamage = 5f; // 공격에 의해 감소하는 체력

    public HealthBar HealthBar;
    public PortalSystem portalSystem;

    private void Start()
    {
        HealthBar = FindAnyObjectByType<HealthBar>();
        portalSystem = FindAnyObjectByType<PortalSystem>();
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

    public void OnButtonClick_RePlay()      // 게임 재시작
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
   
    
}
