using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealthbarsystem : MonoBehaviour
{
    [Header("playerCharacterList")]
    public GameObject[] playerCharacterList = new GameObject[4]; // �÷��̾� �迭

    public GameObject DieImage;    // ���� ���� �̹���
    public GameObject Player; // �÷��̾�
    public Text curHpText;

    [SerializeField]
    private Slider healthBar;
    [Tooltip("�ִ밪")] private float MaxHp = 100;
    [Tooltip("�ּҰ�")] private float curHp = 100;

    private bool enemyattackcheck;
    private float attackDamage = 10f; // ���ݿ� ���� �����ϴ� ü��

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
        // ���� ü�� ���
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
