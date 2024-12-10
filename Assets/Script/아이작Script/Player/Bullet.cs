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
      
        timeAlive += Time.deltaTime;

       
        if (timeAlive >= lifetime)
        {
            Destroy(gameObject); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� �浹���� ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            EnemyHealthBar enemyHealthBar = collision.gameObject.GetComponent<EnemyHealthBar>();
            if (enemyHealthBar != null)
            {
                enemyHealthBar.TakeDamage(damage);  // ������ �������� ��
                Debug.Log($"������ {damage}�� �������� �־����ϴ�.");
            }
            else
            {
                Debug.LogWarning("EnemyHealthBar ������Ʈ�� �����ϴ�!");
            }

            Destroy(gameObject);  
        }
     
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); 
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
