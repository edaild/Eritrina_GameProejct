using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // �̵� �ӵ�
    public float rotationSpeed = 700f; // ȸ�� �ӵ�
    public float attackRange = 1.5f; // ���� ����
    public float attackDamage = 10f; // ���� ������
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform firePoint; // �Ѿ� �߻� ��ġ
    public float bulletSpeed = 20f; // �Ѿ� �ӵ�

    [Header("Player Sounds")]
    public AudioClip walkSound; // �ȴ� �Ҹ�
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    private Rigidbody playerRigidbody;
    private Animator animator;
    private Vector3 moveDirection; // �̵� ����
    private Vector3 attackDirection; // ���� ���� (����Ű�� ����)

    private bool isRotating = false; // ȸ�� ������ Ȯ���ϴ� ����

    private void Start()
    {
        // Rigidbody �� Animator ������Ʈ �ʱ�ȭ
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();

        // AudioSource�� ���ٸ� �߰�
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
            else
            {
                Debug.LogWarning("Walk sound not assigned!");
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
        else
        {
            // animator.SetBool("Attack", false);
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
        // �Ѿ� �߻�
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = attackDirection.normalized * bulletSpeed;
        }
    }
}
