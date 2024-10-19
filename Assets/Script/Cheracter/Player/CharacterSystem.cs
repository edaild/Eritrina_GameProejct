using UnityEngine;
using UnityEngine.UI;

public class CharacterSystem : MonoBehaviour
{
    [Header("Player Movement")]
    [Tooltip("�÷��̾� �ȴ� �ӵ�")] public float playerSpeed = 5f; // �̵� �ӵ�
    [Tooltip("�÷��̾� �ٴ� �ӵ�")] public float runSpeed = 10f; // �ٴ� �ӵ�

    [Header("Character System")]
    [Tooltip("ĳ���� �迭")] public GameObject[] playerCharacter = new GameObject[2]; // ĳ���� �迭
    [Tooltip("��ư �迭")] public Button[] characterButtons; // UI ��ư �迭
    [Tooltip("�ִϸ����� �迭")] public Animator[] animators; // �ִϸ����� �迭

    private Rigidbody playerRigidbody; // Rigidbody

    // Ȱ��ȭ�� ��ư ���� (16���� ���� �ڵ� #3E3593)
    private Color activeColor = new Color32(62, 53, 147, 178); // RGB(62, 53, 147) �� Alpha(255)
    private Color inactiveColor = new Color32(0, 0, 0, 178); // RGB(0, 0, 0) �� Alpha(255)

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

        // Ȱ��ȭ�� ĳ������ �ִϸ����� ��������
        Animator currentAnimator = GetCurrentAnimator();

        if (currentAnimator != null)
        {
            // �ִϸ��̼� ���� ������Ʈ
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
        // �ִϸ����� �迭 �ʱ�ȭ
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
