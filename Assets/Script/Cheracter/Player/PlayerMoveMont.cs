using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMont : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // �̵� �ӵ�
    public float runSpeed = 10f; // �ٴ� �ӵ�
    public float jumpForce = 5f; // ���� ��

    private bool isGrounded; // �� üũ
    private Animator animator; // �ִϸ��̼�
    private Rigidbody playerRigidbody; // Rigidbody

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Ű������ ���� �Է��� �޾ƿ´�.
        float xInput = Input.GetAxis("Horizontal");
        // Ű������ ���� �Է��� �޾ƿ´�.
        float zInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xInput, 0, zInput).normalized;

        // �ٴ� �ӵ� ���
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? runSpeed : playerSpeed;
        playerRigidbody.velocity = new Vector3(movement.x * currentSpeed, playerRigidbody.velocity.y, movement.z * currentSpeed);

        // �ִϸ��̼�
        animator.SetBool("IsWalk", movement != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)); // �ȴ� �ִϸ��̼�
        animator.SetBool("IsRun", Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) && movement != Vector3.zero); // �ٴ� �ִϸ��̼�

        // ����
        if (movement != Vector3.zero)
        {
            transform.LookAt(transform.position + movement);
        }
    }
}
