using UnityEngine;
using UnityEngine.UI;

public class CharacterSystem : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // 이동 속도
    public float runSpeed = 10f; // 뛰는 속도
    public float rotationSpeed = 7f;

    [Header("Character System")]
    public GameObject[] playerCharacter = new GameObject[2]; // 캐릭터 배열
    public Button[] characterButtons; // UI 버튼 배열
    public Animator[] animators; // 애니메이터 배열

    private Rigidbody playerRigidbody; // Rigidbody

    public NpcCharacterController npccharacterController;

    // 활성화된 버튼 색상 (16진수 색상 코드 #3E3593)
    private Color activeColor = new Color32(62, 53, 147, 178); // RGB(62, 53, 147) 및 Alpha(255)
    private Color inactiveColor = new Color32(0, 0, 0, 178); // RGB(0, 0, 0) 및 Alpha(255)

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        npccharacterController = GetComponent<NpcCharacterController>();
        InitializeAnimators();
        CharacterReset();
    }

    private void Update()
    {
        //NotHandleMovementCheck();
        HandleMovement();
        HandleCharacterChangeKeyboard();
    }

    //public void NotHandleMovementCheck()
    //{
    // if (npccharacterController.NpcTextcheck == true)
    //    {
    //        HandleMovement();
    //    }
    //}

    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 카메라의 방향을 가져와서 이동 방향을 계산
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Y축 방향은 무시하고 평면에서의 이동 방향을 계산
        cameraForward.y = 0;
        cameraRight.y = 0;

        // 정규화
        cameraForward.Normalize();
        cameraRight.Normalize();

        // 입력에 따른 이동 벡터 계산
        Vector3 movement = (cameraRight * xInput + cameraForward * zInput).normalized;

        // 현재 속도 결정
        float currentSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? runSpeed : playerSpeed;

        // Rigidbody의 속도 설정
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

        // 플레이어가 이동할 경우 시선 방향 조정
        if (movement != Vector3.zero)
        {
            // 회전 방향을 설정하여 플레이어가 이동 방향을 바라보도록 함
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
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