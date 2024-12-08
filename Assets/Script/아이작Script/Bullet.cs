using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;  // 총알의 데미지
    public float lifetime = 0.5f; // 총알의 생명 시간 (5초)
    private float timeAlive = 0f; // 총알이 살아있는 시간

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
        // 적과 충돌했을 때
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            EnemyHealthBar enemyHealthBar = collision.gameObject.GetComponent<EnemyHealthBar>();
            if (enemyHealthBar != null)
            {
                enemyHealthBar.TakeDamage(damage);  // 적에게 데미지를 줌
                Debug.Log($"적에게 {damage}의 데미지를 주었습니다.");
            }
            else
            {
                Debug.LogWarning("EnemyHealthBar 컴포넌트가 없습니다!");
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
