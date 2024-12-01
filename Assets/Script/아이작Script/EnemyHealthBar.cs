using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public float health = 50f;        // 적의 체력
    public float maxHealth = 50f;     // 최대 체력
    public Slider healthBar;          // 체력 바 UI 슬라이더

    public PortalSystem portalSystem;

    private bool isDead = false;      // 적이 죽었는지 여부를 추적하는 변수

    private void Start()
    {
        portalSystem = FindAnyObjectByType<PortalSystem>();
    }

    // 데미지를 받을 때 호출되는 메소드
    public void TakeDamage(float damage)
    {
        if (isDead) return;  // 적이 이미 죽었다면 추가 데미지를 받지 않음

        health -= damage; // 체력 감소
        if (health <= 0f)
        {
            health = 0f;  // 체력이 0 이하로 떨어지지 않도록 처리
            Die();        // 적이 죽었을 때 처리
        }

        // 체력 바 업데이트
        //if (healthBar != null)
        //{
        //    healthBar.value = health / maxHealth;  // 슬라이더 값은 0~1 사이로 설정
        //}
    }

    // 적이 죽었을 때 호출되는 메소드
    private void Die()
    {
        if (isDead) return; 

        isDead = true;  // 죽음 상태로 설정
     
        Destroy(gameObject);  // 적 오브젝트 삭제
        portalSystem.EnemyCount++;  // 한 번만 카운트 증가
    }
}
