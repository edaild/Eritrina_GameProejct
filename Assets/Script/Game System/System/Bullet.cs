using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;  // �� ��ü�� GameObject�� ����
    public PlayerAttack playerAttack;  // PlayerAttack ��ũ��Ʈ
    public float speed = 10f;  // �Ѿ� �ӵ�

    private void Start()
    {
        // PlayerAttack�� null�� ��츦 �����ϴ� null üũ
        if (playerAttack == null)
        {
            playerAttack = FindObjectOfType<PlayerAttack>();  // PlayerAttack ��ũ��Ʈ ã�� �Ҵ�
        }

        // enemy�� null�� ��� ã���ִ� �ڵ� �߰�
        if (enemy == null)
        {
            Debug.LogWarning("Enemy ��ü�� �Ҵ���� �ʾҽ��ϴ�. ���� �Ҵ��� �ּ���.");
        }
    }

    private void Update()
    {
        if (enemy != null)
        {
            // �� �������� ȸ��
            Vector3 direction = enemy.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);  // ȸ�� �ε巴��

            // �Ѿ��� �� �������� �̵�
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);  // ���� ��ǥ�� ���� �̵�
        }
    }

    // �Ѿ� �߻� �Լ�
    public void Firing()
    {
        gameObject.SetActive(true);  // �Ѿ��� Ȱ��ȭ
    }

    // �浹 ó��
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // ���� �浹 ��
        {
            Debug.Log("�÷��̾ ������ �Ϲ� ������ �����߽��ϴ�.");
            if (playerAttack != null)
            {
                playerAttack.attackCheckN = true;  // ���� üũ
            }
            gameObject.SetActive(false);  // �Ѿ� ��Ȱ��ȭ
        }
    }
}
