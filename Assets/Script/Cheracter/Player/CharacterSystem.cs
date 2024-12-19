using UnityEngine;

public class CharacterSystem : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f;
    public float rotationSpeed = 7f;

    [Header("Character System")]
    public GameObject[] playerCharacter = new GameObject[4];

    private Rigidbody playerRigidbody;

    public Animator an;

    private AudioSource audioSource;
    public AudioClip walkSound;

    private bool isWalking = false;

    [Header("Walking Sound Settings")]
    public float walkSoundVolume = 0.5f; // �ȴ� �Ҹ��� ���� (0.0 ~ 1.0 ����)

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        // AudioSource ������Ʈ�� ���ٸ� �߰�
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // �ȴ� �Ҹ� ���� ����
        audioSource.volume = walkSoundVolume;

        // walkSound�� �Ҵ�Ǿ� �ִ��� Ȯ��
        if (walkSound == null)
        {
            Debug.LogError("walkSound AudioClip is not assigned!");
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraRight * xInput + cameraForward * zInput).normalized;

        playerRigidbody.velocity = new Vector3(movement.x * playerSpeed, playerRigidbody.velocity.y, movement.z * playerSpeed);

        bool isMoving = movement.magnitude > 0;

        // "IsWalk" �Ķ���Ͱ� animator�� �����ϴ��� Ȯ��
        if (an != null)
        {
            an.SetBool("IsWalk", isMoving);
        }
        else
        {
            Debug.LogError("Animator component is not assigned!");
        }

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        HandleAudio(isMoving);
    }

    private void HandleAudio(bool isMoving)
    {
        if (isMoving)  // �Ȱ� ���� ��
        {
            if (!isWalking)
            {
                isWalking = true;
                if (walkSound != null)
                {
                    audioSource.clip = walkSound;  // �ȱ� �Ҹ� ����
                    audioSource.loop = true;       // �Ҹ� �ݺ� ����
                    audioSource.Play();            // �Ҹ� ���
                }
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                audioSource.Stop();  // �Ҹ� ���߱�
            }
        }
    }

    // �ȴ� �Ҹ��� ������ �����ϴ� �޼ҵ�
    public void SetWalkSoundVolume(float volume)
    {
        walkSoundVolume = Mathf.Clamp01(volume);  // ������ 0.0 ~ 1.0 ���̷� ����
        audioSource.volume = walkSoundVolume;     // ����� �ҽ��� ������ �ݿ�
    }
}
