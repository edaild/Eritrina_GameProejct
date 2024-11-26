using UnityEngine;

public class EnemyHeathBar : MonoBehaviour
{
    public float health = 50f;        // 적의 체력
    public float maxHealth = 50f;     // 최대 체력

    // 데미지를 받을 때 호출되는 메소드
    public void TakeDamage(float damage)
    {
        health -= damage; // 체력 감소
        if (health <= 0f)
        {
            health = 0f;  // 체력이 0 이하로 떨어지지 않도록 처리
            Die();        // 적이 죽었을 때 처리
        }
    }

    // 적이 죽었을 때 호출되는 메소드
    private void Die()
    {
        // 죽었을 때의 처리 (예: 애니메이션, 사라짐 등)
        Destroy(gameObject);  // 적 오브젝트 삭제
    }
}
