using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;  // �Ѿ��� ������

    private void OnCollisionEnter(Collision collision)
    {
        // ���� �浹���� ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // EnemyHeathBar�� ã�Ƽ� ü�� ����
            EnemyHeathBar enemyHealthBar = collision.gameObject.GetComponent<EnemyHeathBar>();
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
