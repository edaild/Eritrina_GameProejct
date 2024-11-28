using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;  // �Ѿ��� ������
    public float lifetime = 0.5f; // �Ѿ��� ���� �ð� (5��)
    private float timeAlive = 0f; // �Ѿ��� ����ִ� �ð�

    private void Update()
    {
        // �Ѿ��� ����ִ� �ð� ����
        timeAlive += Time.deltaTime;

        // 5�ʰ� ������ �Ѿ� ����
        if (timeAlive >= lifetime)
        {
            Destroy(gameObject); // �Ѿ� ����
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� �浹���� ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // EnemyHealthBar�� ã�Ƽ� ü�� ����
            EnemyHealthBar enemyHealthBar = collision.gameObject.GetComponent<EnemyHealthBar>();
            if (enemyHealthBar != null)
            {
                enemyHealthBar.TakeDamage(damage);  // ������ �������� ��
            }

            Destroy(gameObject);  // �Ѿ� ����
        }

        // ���� �浹���� ��
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);  // �Ѿ� ����
        }
    }
}

