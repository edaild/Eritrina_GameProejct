using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerMoveMont : MonoBehaviour
{

    [Header("Player Check")]

    public GameObject[] player = new GameObject[4]; // 플레이어 배열 추가

    [Header("Player Movement")]
    public float playerSpeed; // 이동 속도
    public float jumpForce;  // 점프 힘

    private bool isGrounded; // 땅 체크
    private Animator animator; // 애니매이션
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
        // 키보드의 수평 입력을 받아온다.
        float xInput = Input.GetAxis("Horizontal");
        // 키보드의 수직 입력을 받아온다.
        float zInput = Input.GetAxis("Vertical");

        Vector3 Movemont = new Vector3(xInput, 0, zInput).normalized;

        playerRigidbody.velocity = Movemont * playerSpeed * Time.deltaTime;

        animator.SetBool("IsWark", Movemont != Vector3.zero); //  에니메이션 적용

        transform.LookAt(transform.position + Movemont);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            // 함수가 호출될 경우 위쪽방향으로 무게를 적용하고 순간적 인 힘을 준다
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 땅에 있는지 Check
        isGrounded = true;
    }
}