using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerMoveMont : MonoBehaviour
{

    [Header("Player Check")]

    public GameObject[] player = new GameObject[4]; // �÷��̾� �迭 �߰�

    [Header("Player Movement")]
    public float playerSpeed; // �̵� �ӵ�
    public float jumpForce;  // ���� ��

    private bool isGrounded; // �� üũ
    private Animator animator; // �ִϸ��̼�
    private Rigidbody playerRigidbody; // playerRigidbody

    private void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        HandleMovement();
        HandleJump();

    }

    private void HandleMovement()
    {
        // Ű������ ���� �Է��� �޾ƿ´�.
        float xInput = Input.GetAxis("Horizontal");
        // Ű������ ���� �Է��� �޾ƿ´�.
        float zInput = Input.GetAxis("Vertical");

        Vector3 Movemont = new Vector3(xInput, 0, zInput).normalized;

        playerRigidbody.velocity = Movemont * playerSpeed * Time.deltaTime;

        animator.SetBool("IsWark", Movemont != Vector3.zero); //  ���ϸ��̼� ����

        transform.LookAt(transform.position + Movemont);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            // �Լ��� ȣ��� ��� ���ʹ������� ���Ը� �����ϰ� ������ �� ���� �ش�
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ ���� �ִ��� Check
        isGrounded = true;
    }
}