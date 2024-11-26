using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;  // 총알의 데미지

    private void OnCollisionEnter(Collision collision)
    {
        // 적과 충돌했을 때
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // EnemyHeathBar를 찾아서 체력 감소
            EnemyHeathBar enemyHealthBar = collision.gameObject.GetComponent<EnemyHeathBar>();
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
