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
        // 총알이 살아있는 시간 갱신
        timeAlive += Time.deltaTime;

        // 5초가 지나면 총알 삭제
        if (timeAlive >= lifetime)
        {
            Destroy(gameObject); // 총알 삭제
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 적과 충돌했을 때
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // EnemyHealthBar를 찾아서 체력 감소
            EnemyHealthBar enemyHealthBar = collision.gameObject.GetComponent<EnemyHealthBar>();
            if (enemyHealthBar != null)
            {
                enemyHealthBar.TakeDamage(damage);  // 적에게 데미지를 줌
            }

            Destroy(gameObject);  // 총알 삭제
        }

        // 벽과 충돌했을 때
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);  // 총알 삭제
        }
    }
}

