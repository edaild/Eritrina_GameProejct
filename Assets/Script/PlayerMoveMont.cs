using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerMoveMont : MonoBehaviour
{
   
    public float playerSpeed;
    public float jumpForce;
    public float rotSpeed;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.4f;

    private bool isGrounded;
   // private Animator animator;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
       //animator = GetComponent<Animator>();
        isGrounded = true;
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 Movemont = new Vector3 (xInput, 0, zInput);

        playerRigidbody.velocity = Movemont * playerSpeed * rotSpeed * Time.deltaTime;

       // animator.SetBool("IsWark", Movemont != Vector3.zero); 

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           // animator.SetBool("IsRun", Movemont != Vector3.zero);
        }

        transform.LookAt(transform.position + Movemont);

        isGrounded = Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, groundCheckDistance, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded  == true)
        {
            Jump();
        }
    }


    private void Jump()
    {
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
