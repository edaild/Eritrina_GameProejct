using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerAttack PlayerAttack;

    private void Start()
    {
        PlayerAttack = FindAnyObjectByType<PlayerAttack>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�÷��̾ ������ �Ϲݰ����� �����ؽ��ϴ�.");
            PlayerAttack.attackCheckN = true;
        }
    }
}

