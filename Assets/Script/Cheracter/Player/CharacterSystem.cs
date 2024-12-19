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
    public float walkSoundVolume = 0.5f; // 걷는 소리의 볼륨 (0.0 ~ 1.0 범위)

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        // AudioSource 컴포넌트가 없다면 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 걷는 소리 볼륨 설정
        audioSource.volume = walkSoundVolume;

        // walkSound가 할당되어 있는지 확인
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

        // "IsWalk" 파라미터가 animator에 존재하는지 확인
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
        if (isMoving)  // 걷고 있을 때
        {
            if (!isWalking)
            {
                isWalking = true;
                if (walkSound != null)
                {
                    audioSource.clip = walkSound;  // 걷기 소리 설정
                    audioSource.loop = true;       // 소리 반복 설정
                    audioSource.Play();            // 소리 재생
                }
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                audioSource.Stop();  // 소리 멈추기
            }
        }
    }

    // 걷는 소리의 볼륨을 설정하는 메소드
    public void SetWalkSoundVolume(float volume)
    {
        walkSoundVolume = Mathf.Clamp01(volume);  // 볼륨을 0.0 ~ 1.0 사이로 제한
        audioSource.volume = walkSoundVolume;     // 오디오 소스의 볼륨에 반영
    }
}
