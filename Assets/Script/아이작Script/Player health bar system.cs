using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Playerhealthbarsystem : HealthBar
{
    public GameObject cube;         // 재시작 시 플레이어 재생성 위치
    public GameObject DieImage;    // 게임 오버 이미지
    public GameObject Player;       // 플레이어
    public Text curHpText;

    public bool enemyattackcheck;



    public HealthBar HealthBar;
    public PortalSystem portalSystem;
    public EnemyData enemyData;

    private void Start()
    {
        HealthBar = FindAnyObjectByType<HealthBar>();
        portalSystem = FindAnyObjectByType<PortalSystem>();
        enemyData = FindAnyObjectByType<EnemyData>();
    }

    private void Update()
    {
        curHpText.text = $"{(int)curHp} / {(int)MaxHp}";
        handleHp();
        Die();
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
        enemyData.CurHealth = enemyData.MaxHealth;
        SceneManager.LoadScene(sceneName);
    }
   
    
}
