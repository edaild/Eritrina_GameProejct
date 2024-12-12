using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // �̵� �ӵ�
    public float rotationSpeed = 700f; // ȸ�� �ӵ�
    public float attackRange = 2f; // ���� ����
    public float attackDamage = 10f; // ���� ������
    public GameObject bulletPrefab; // �Ѿ� ������
    public GameObject SPbulletPrefab;   // Ư���� �Ѿ� ������
    public Transform firePoint; // �Ѿ� �߻� ��ġ
    public float bulletSpeed = 20f; // �Ѿ� �ӵ�

    

    [Header("Player Sounds")]
    public AudioClip walkSound; // �ȴ� �Ҹ�
    public bool spammoCheck;    // Ư�� �Ѿ�üũ

    private AudioSource audioSource; // ����� �ҽ� ������Ʈ
    private Rigidbody playerRigidbody;
    private Animator animator;
    private Vector3 moveDirection; // �̵� ����
    private Vector3 attackDirection; // ���� ���� (����Ű�� ����)

    private bool isRotating = false;
    private bool spbulletCheck = false; // �ùٸ��� �ʱ�ȭ
    private float spbulletTimer = 0f; // Ư���� �Ѿ� ���� ���� Ÿ�̸�
   
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        playerRigidbody.freezeRotation = true;  // ������ ȸ�� ����
    }

    private void Update()
    {
        HandleMovement();
        HandleAttack();

        // Ư�� �Ѿ� ��ȯ (Enter Ű�� ����)
        if (spammoCheck)
        {
            ActivateSpecialBullet(); // Ư���� �Ѿ� ���� Ȱ��ȭ
            Debug.Log("Ư���Ѿ��� Ȱ��ȭ �˴ϴ�.");
        }

        // Ư�� �Ѿ� ���°� Ȱ��ȭ�� ��� Ÿ�̸Ӹ� �۵����� 30�� �Ŀ� ��Ȱ��ȭ
        if (spbulletCheck)
        {
            spbulletTimer += Time.deltaTime;

            if (spbulletTimer >= 30f) // 30�� ��� ��
            {
                DeactivateSpecialBullet(); // 2�� �� Ư�� �Ѿ� ��Ȱ��ȭ
            }
        }
    }

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // �̵� �Է� üũ (WASD �Ǵ� ����Ű)
        if (Input.GetKey(KeyCode.W))  // ���� �̵�
        {
            moveZ = 1f;
            animator.SetBool("IsWalk", true);
        }
        else if (Input.GetKey(KeyCode.S))  // �Ʒ��� �̵�
        {
            moveZ = -1f;
            animator.SetBool("IsWalk", true);
        }
        else if (Input.GetKey(KeyCode.A))  // �������� �̵�
        {
            moveX = -1f;
            animator.SetBool("IsWalk", true);
        }
        else if (Input.GetKey(KeyCode.D))  // ���������� �̵�
        {
            moveX = 1f;
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }

        // �̵� ���� (�ε巯�� �̵�)
        moveDirection = new Vector3(moveX, 0, moveZ).normalized * playerSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + moveDirection);

        // �̵� �������� ȸ��
        if (moveDirection != Vector3.zero && !isRotating) // ȸ�� ���� �ƴ� ���� ȸ��
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // �ȴ� �Ҹ� ���: �̵��� ���� �Ҹ� ���
        if (moveDirection != Vector3.zero && !audioSource.isPlaying)
        {
            if (walkSound != null)
            {
                audioSource.clip = walkSound;
                audioSource.Play();
            }
        }
        // ���� �� �ȴ� �Ҹ� ����
        else if (moveDirection == Vector3.zero && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void HandleAttack()
    {
        // ����Ű�� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.UpArrow)) attackDirection = Vector3.forward;  // ����
        if (Input.GetKeyDown(KeyCode.DownArrow)) attackDirection = Vector3.back;    // �Ʒ���
        if (Input.GetKeyDown(KeyCode.LeftArrow)) attackDirection = Vector3.left;    // ����
        if (Input.GetKeyDown(KeyCode.RightArrow)) attackDirection = Vector3.right;   // ������

        // ����Ű�� ������ �� ���� �������� ȸ���ϰ� �Ѿ� �߻�
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateTowardsAttackDirection();  // ���� �������� ��� ȸ��
            FireBullet();
            animator.SetBool("Attack", true);  // ���� �ִϸ��̼� ����         
        }
    }

    // ���� �������� ��� ȸ���ϴ� �޼ҵ�
    private void RotateTowardsAttackDirection()
    {
        // ���� �������� �ٷ� ȸ��
        if (attackDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(attackDirection);
            transform.rotation = targetRotation; // ��� ȸ��
        }
    }

    // �Ѿ� �߻� �޼ҵ�
    private void FireBullet()
    {
        GameObject bullet;

        // Ư���� �Ѿ��� ���õǾ��� ��
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

    // Ư�� �Ѿ� ���� Ȱ��ȭ �޼ҵ�
    private void ActivateSpecialBullet()
    {
        if (!spbulletCheck) // �̹� Ȱ��ȭ�Ǿ��� ���� �ٽ� �������� ����
        {
            Debug.Log("Ư���� �Ѿ��� Ȱ��ȭ�Ǿ����ϴ�.");
            spbulletCheck = true;
            spbulletTimer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    // Ư�� �Ѿ� ���� ��Ȱ��ȭ �޼ҵ�
    private void DeactivateSpecialBullet()
    {
        Debug.Log("Ư���� �Ѿ��� ��Ȱ��ȭ�Ǿ����ϴ�.");
        spbulletCheck = false;
        spammoCheck = false;
        spbulletTimer = 0f; // Ÿ�̸� �ʱ�ȭ
    }
}
