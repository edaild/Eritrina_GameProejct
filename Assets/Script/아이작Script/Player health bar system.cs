using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Playerhealthbarsystem : HealthBar
{
    public GameObject cube;         // ����� �� �÷��̾� ����� ��ġ
    public GameObject DieImage;    // ���� ���� �̹���
    public GameObject Player;       // �÷��̾�
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
            curHp = 0; // ü���� 0���� ����

            DieImage.SetActive(true);
            Player.gameObject.SetActive(false);
           
        }
    }

    public void OnButtonClick_RePlay()      // ���� �����
    {
        
        string sceneName = SceneManager.GetActiveScene().name;
        enemyData.CurHealth = enemyData.MaxHealth;
        SceneManager.LoadScene(sceneName);
    }
   
    
}
