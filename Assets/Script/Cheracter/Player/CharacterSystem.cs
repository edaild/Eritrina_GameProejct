using UnityEngine;
using UnityEngine.UI;

public class CharacterSystem : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // 이동 속도
    public float runSpeed = 10f; // 뛰는 속도
    public float rotationSpeed = 7f;

    [Header("Character System")]
    public GameObject[] playerCharacter = new GameObject[4]; // 캐릭터 배열
    public Button[] characterButtons; // UI 버튼 배열
    public Animator[] animators; // 애니메이터 배열

    public GameObject TextUI; // UI 텍스트 오브젝트

    private Rigidbody playerRigidbody; // Rigidbody

    public MainQuest01 mainQuest01;

    // 활성화된 버튼 색상 (16진수 색상 코드 #3E3593)
    private Color activeColor = new Color32(62, 53, 147, 178); // RGB(62, 53, 147) 및 Alpha(255)
    private Color inactiveColor = new Color32(0, 0, 0, 178); // RGB(0, 0, 0) 및 Alpha(255)

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        mainQuest01 = GetComponent<MainQuest01>();
        InitializeAnimators();
        CharacterReset();
    }

    private void Update()
    {
        NotHandleMovementCheck();
        HandleCharacterChangeKeyboard();
    }

    public void NotHandleMovementCheck()
    {
        if (!TextUI.activeSelf || Input.GetKeyDown(KeyCode.LeftAlt)) // TextUI가 비활성화된 경우에만 HandleMovement 호출
        {
            HandleMovement();
        }
        else
        {
            StopMovement(); // TextUI가 활성화된 경우에는 이동 정지
        }
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

        float currentSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? runSpeed : playerSpeed;

        playerRigidbody.velocity = new Vector3(movement.x * currentSpeed, playerRigidbody.velocity.y, movement.z * currentSpeed);

        Animator currentAnimator = GetCurrentAnimator();

        if (currentAnimator != null)
        {
            bool isMoving = movement != Vector3.zero;
            currentAnimator.SetBool("IsWalk", isMoving && !Input.GetKey(KeyCode.LeftShift));
            currentAnimator.SetBool("IsRun", isMoving && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)));
        }

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void StopMovement()
    {
        playerRigidbody.velocity = Vector3.zero; // 움직임을 정지
        Animator currentAnimator = GetCurrentAnimator();
        if (currentAnimator != null)
        {
            currentAnimator.SetBool("IsWalk", false);
            currentAnimator.SetBool("IsRun", false);
        }
    }

    private void InitializeAnimators()
    {
        animators = new Animator[playerCharacter.Length];
        for (int i = 0; i < playerCharacter.Length; i++)
        {
            animators[i] = playerCharacter[i].GetComponent<Animator>();
        }
    }

    private Animator GetCurrentAnimator()
    {
        for (int i = 0; i < playerCharacter.Length; i++)
        {
            if (playerCharacter[i].activeSelf)
            {
                return animators[i];
            }
        }
        return null;
    }

    private void CharacterReset()
    {
        if (playerCharacter.Length > 0)
        {
            for (int i = 0; i < playerCharacter.Length; i++)
            {
                playerCharacter[i].SetActive(i == 0);
                characterButtons[i].image.color = i == 0 ? activeColor : inactiveColor;
            }
        }
    }

    public void OnButtonClickCharacter(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < playerCharacter.Length)
        {
            for (int i = 0; i < playerCharacter.Length; i++)
            {
                playerCharacter[i].SetActive(i == characterIndex);
                characterButtons[i].image.color = i == characterIndex ? activeColor : inactiveColor;
            }
        }
    }

    private void HandleCharacterChangeKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnButtonClickCharacter(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnButtonClickCharacter(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnButtonClickCharacter(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnButtonClickCharacter(3);
        }
    }
}
