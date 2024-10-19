using UnityEngine;
using UnityEngine.UI;

public class CharacterSystem : MonoBehaviour
{
    [Header("Player Movement")]
    [Tooltip("플레이어 걷는 속도")] public float playerSpeed = 5f; // 이동 속도
    [Tooltip("플레이어 뛰는 속도")] public float runSpeed = 10f; // 뛰는 속도

    [Header("Character System")]
    [Tooltip("캐릭터 배열")] public GameObject[] playerCharacter = new GameObject[2]; // 캐릭터 배열
    [Tooltip("버튼 배열")] public Button[] characterButtons; // UI 버튼 배열
    [Tooltip("애니메이터 배열")] public Animator[] animators; // 애니메이터 배열

    private Rigidbody playerRigidbody; // Rigidbody

    // 활성화된 버튼 색상 (16진수 색상 코드 #3E3593)
    private Color activeColor = new Color32(62, 53, 147, 178); // RGB(62, 53, 147) 및 Alpha(255)
    private Color inactiveColor = new Color32(0, 0, 0, 178); // RGB(0, 0, 0) 및 Alpha(255)

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        InitializeAnimators();
        CharacterReset();
    }

    private void Update()
    {
        HandleMovement();
        HandleCharacterChangeKeyboard();
    }

    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xInput, 0, zInput).normalized;

        float currentSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? runSpeed : playerSpeed;
        playerRigidbody.velocity = new Vector3(movement.x * currentSpeed, playerRigidbody.velocity.y, movement.z * currentSpeed);

        // 활성화된 캐릭터의 애니메이터 가져오기
        Animator currentAnimator = GetCurrentAnimator();

        if (currentAnimator != null)
        {
            // 애니메이션 상태 업데이트
            bool isMoving = movement != Vector3.zero;
            currentAnimator.SetBool("IsWalk", isMoving && !Input.GetKey(KeyCode.LeftShift));
            currentAnimator.SetBool("IsRun", isMoving && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)));
        }

        if (movement != Vector3.zero)
        {
            transform.LookAt(transform.position + movement);
        }
    }

    private void InitializeAnimators()
    {
        // 애니메이터 배열 초기화
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
