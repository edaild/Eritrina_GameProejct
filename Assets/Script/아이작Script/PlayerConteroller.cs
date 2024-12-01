using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // 이동 속도
    public float rotationSpeed = 700f; // 회전 속도
    public float attackRange = 1.5f; // 공격 범위
    public float attackDamage = 10f; // 공격 데미지
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 총알 발사 위치
    public float bulletSpeed = 20f; // 총알 속도

    private Rigidbody playerRigidbody;
    private Animator animator;
    private Vector3 moveDirection; // 이동 방향
    private Vector3 attackDirection; // 공격 방향 (방향키로 설정)

    private bool isRotating = false; // 회전 중인지 확인하는 변수

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerRigidbody.freezeRotation = true;  // 물리적 회전 방지
    }

    private void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // 이동 입력 체크 (WASD 또는 방향키)
        if (Input.GetKey(KeyCode.W))  // 위쪽 이동
        {
            moveZ = 1f;
            animator.SetBool("IsWalk", true);
        }
        else if (Input.GetKey(KeyCode.S))  // 아래쪽 이동
        {
            moveZ = -1f;
            animator.SetBool("IsWalk", true);
        }

        else if (Input.GetKey(KeyCode.A))  // 왼쪽으로 이동
        {
            moveX = -1f;
            animator.SetBool("IsWalk", true);
        }
        else if (Input.GetKey(KeyCode.D))  // 오른쪽으로 이동
        {
            moveX = 1f;
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }

        // 이동 적용 (부드러운 이동)
        moveDirection = new Vector3(moveX, 0, moveZ).normalized * playerSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + moveDirection);

        // 이동 방향으로 회전
        if (moveDirection != Vector3.zero && !isRotating) // 회전 중이 아닐 때만 회전
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleAttack()
    {
        // 방향키로 공격 방향 설정
        if (Input.GetKeyDown(KeyCode.UpArrow)) attackDirection = Vector3.forward;  // 위쪽
        if (Input.GetKeyDown(KeyCode.DownArrow)) attackDirection = Vector3.back;    // 아래쪽
        if (Input.GetKeyDown(KeyCode.LeftArrow)) attackDirection = Vector3.left;    // 왼쪽
        if (Input.GetKeyDown(KeyCode.RightArrow)) attackDirection = Vector3.right;   // 오른쪽

        // 방향키를 눌렀을 때 공격 방향으로 회전하고 총알 발사
        if (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateTowardsAttackDirection();  // 공격 방향으로 즉시 회전
            FireBullet();
            animator.SetTrigger("Attack");  // 공격 애니메이션 실행         
        }
    }

    // 공격 방향으로 즉시 회전하는 메소드
    private void RotateTowardsAttackDirection()
    {
        // 공격 방향으로 바로 회전
        if (attackDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(attackDirection);
            transform.rotation = targetRotation; // 즉시 회전
        }
    }

    // 총알 발사 메소드
    private void FireBullet()
    {
        // 총알 발사
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = attackDirection.normalized * bulletSpeed;
        }
    }
}
