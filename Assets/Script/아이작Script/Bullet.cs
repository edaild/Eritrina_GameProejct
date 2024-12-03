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

        // lifetime이 경과하면 총알 삭제
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
            // 적의 체력 바를 찾아서 데미지 전달
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

            Destroy(gameObject);  // 총알 삭제
        }
        // 벽과 충돌했을 때
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽과 충돌하여 총알이 파괴되었습니다.");
            Destroy(gameObject);  // 총알 삭제
        }
    }
}
