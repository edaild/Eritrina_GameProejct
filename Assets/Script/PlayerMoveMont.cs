using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerMoveMont : MonoBehaviour
{
   

    [SerializeField]
    [Header("플레이어 움직임")]
    public float playerSpeed; // 속도
    public float jumpForce;  // 점프 힘

    public bool isGrounded; // 땅 체크
    private Animator animator; // 애니매이션
    private Rigidbody playerRigidbody; // playerRigidbody

    private void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float xInput = Input.GetAxis("Horizontal"); // 좌우
        float zInput = Input.GetAxis("Vertical"); // 상하

        Vector3 Movemont = new Vector3(xInput, 0, zInput).normalized;

        playerRigidbody.velocity = Movemont * playerSpeed * Time.deltaTime;

        animator.SetBool("IsWark", Movemont != Vector3.zero); //  에니메이션 적용

        transform.LookAt(transform.position + Movemont);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
    }


    private void Jump()
    {
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
