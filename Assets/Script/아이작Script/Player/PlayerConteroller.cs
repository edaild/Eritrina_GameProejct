using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // 이동 속도
    public float rotationSpeed = 700f; // 회전 속도
    public float attackRange = 2f; // 공격 범위
    public float attackDamage = 10f; // 공격 데미지
    public GameObject bulletPrefab; // 총알 프리팹
    public GameObject SPbulletPrefab;   // 특별한 총알 프리팹
    public Transform firePoint; // 총알 발사 위치
    public float bulletSpeed = 20f; // 총알 속도

    

    [Header("Player Sounds")]
    public AudioClip walkSound; // 걷는 소리
    public bool spammoCheck;    // 특수 총알체크

    private AudioSource audioSource; // 오디오 소스 컴포넌트
    private Rigidbody playerRigidbody;
    private Animator animator;
    private Vector3 moveDirection; // 이동 방향
    private Vector3 attackDirection; // 공격 방향 (방향키로 설정)

    private bool isRotating = false;
    private bool spbulletCheck = false; // 올바르게 초기화
    private float spbulletTimer = 0f; // 특별한 총알 상태 유지 타이머
   
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        playerRigidbody.freezeRotation = true;  // 물리적 회전 방지
    }

    private void Update()
    {
        HandleMovement();
        HandleAttack();

        // 특수 총알 전환 (Enter 키로 설정)
        if (spammoCheck)
        {
            ActivateSpecialBullet(); // 특별한 총알 상태 활성화
            Debug.Log("특수총알이 활성화 됩니다.");
        }

        // 특수 총알 상태가 활성화된 경우 타이머를 작동시켜 30초 후에 비활성화
        if (spbulletCheck)
        {
            spbulletTimer += Time.deltaTime;

            if (spbulletTimer >= 30f) // 30초 경과 시
            {
                DeactivateSpecialBullet(); // 2분 후 특수 총알 비활성화
            }
        }
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

        // 걷는 소리 재생: 이동할 때만 소리 재생
        if (moveDirection != Vector3.zero && !audioSource.isPlaying)
        {
            if (walkSound != null)
            {
                audioSource.clip = walkSound;
                audioSource.Play();
            }
        }
        // 멈출 때 걷는 소리 중지
        else if (moveDirection == Vector3.zero && audioSource.isPlaying)
        {
            audioSource.Stop();
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
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateTowardsAttackDirection();  // 공격 방향으로 즉시 회전
            FireBullet();
            animator.SetBool("Attack", true);  // 공격 애니메이션 실행         
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
        GameObject bullet;

        // 특별한 총알이 선택되었을 때
        if (spbulletCheck)
        {
            bullet = Instantiate(SPbulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = attackDirection.normalized * bulletSpeed;
        }
    }

    // 특수 총알 상태 활성화 메소드
    private void ActivateSpecialBullet()
    {
        if (!spbulletCheck) // 이미 활성화되었을 때는 다시 설정하지 않음
        {
            Debug.Log("특별한 총알이 활성화되었습니다.");
            spbulletCheck = true;
            spbulletTimer = 0f; // 타이머 초기화
        }
    }

    // 특수 총알 상태 비활성화 메소드
    private void DeactivateSpecialBullet()
    {
        Debug.Log("특별한 총알이 비활성화되었습니다.");
        spbulletCheck = false;
        spammoCheck = false;
        spbulletTimer = 0f; // 타이머 초기화
    }
}
