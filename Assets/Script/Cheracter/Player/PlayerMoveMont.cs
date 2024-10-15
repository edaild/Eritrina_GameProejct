using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMont : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // 이동 속도
    public float runSpeed = 10f; // 뛰는 속도
    public float jumpForce = 5f; // 점프 힘

    private bool isGrounded; // 땅 체크
    private Animator animator; // 애니메이션
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
        // 키보드의 수평 입력을 받아온다.
        float xInput = Input.GetAxis("Horizontal");
        // 키보드의 수직 입력을 받아온다.
        float zInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xInput, 0, zInput).normalized;

        // 뛰는 속도 계산
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? runSpeed : playerSpeed;
        playerRigidbody.velocity = new Vector3(movement.x * currentSpeed, playerRigidbody.velocity.y, movement.z * currentSpeed);

        // 애니메이션
        animator.SetBool("IsWalk", movement != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)); // 걷는 애니메이션
        animator.SetBool("IsRun", Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) && movement != Vector3.zero); // 뛰는 애니메이션

        // 방향
        if (movement != Vector3.zero)
        {
            transform.LookAt(transform.position + movement);
        }
    }
}
