using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBar;          // 체력 바 UI 슬라이더
    public EnemyData enemyData;      // 적의 데이터
    public PortalSystem portalSystem; // 포탈 시스템 (적이 죽을 때마다 호출)

    private bool isDead = false;      // 적이 죽었는지 여부를 추적하는 변수

    private void Start()
    {
        // FindObjectOfType을 사용하여 시스템과 데이터를 찾아 초기화합니다.
        portalSystem = FindObjectOfType<PortalSystem>();
       // enemyData = FindObjectOfType<EnemyData>();

        // 체력 바 초기화 (체력에 맞게 슬라이더 값을 설정)
        if (healthBar != null)
        {
            healthBar.maxValue = enemyData.health;
            healthBar.value = enemyData.health;
        }
    }

    // 데미지를 받을 때 호출되는 메소드
    public void TakeDamage(float damage)
    {
        if (isDead) return;  // 적이 이미 죽었으면 더 이상 데미지를 받지 않음

        enemyData.health -= damage; // 체력 감소
        if (enemyData.health <= 0f)
        {
            enemyData.health = 0f;  // 체력이 0 이하로 떨어지지 않도록 처리
            Die();        // 적이 죽었을 때 처리
        }

        // 체력 바 업데이트
        if (healthBar != null)
        {
            healthBar.value = enemyData.health;  // 슬라이더 값은 0~최대 체력 사이로 설정
        }
    }

    // 적이 죽었을 때 호출되는 메소드
    private void Die()
    {
        if (isDead) return; // 이미 죽었으면 다시 실행하지 않음

        isDead = true;  // 죽음 상태로 설정

        Destroy(gameObject);  // 적 오브젝트 삭제

        // 포탈 시스템의 EnemyCount 증가
        if (portalSystem != null)
        {
            portalSystem.EnemyCount++;  // 한 번만 카운트 증가
        }
    }
}
