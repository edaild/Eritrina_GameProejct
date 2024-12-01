using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;

public class Playerhealthbarsystem : HealthBar
{
    public GameObject cube;         // ����� �� �÷��̾� ����� ��ġ
    public GameObject DieImage;    // ���� ���� �̹���
    public GameObject Player;       // �÷��̾�
    public Text curHpText;

    public bool enemyattackcheck;
    private float attackDamage = 5f; // ���ݿ� ���� �����ϴ� ü��

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

    public void OnButtonClick_RePlay()      // ���� �����
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
   
    
}
