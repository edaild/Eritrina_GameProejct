using UnityEngine;
using UnityEngine.UI;

public class PlayerConteroller : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 5f; // 이동 속도
    public float runSpeed = 10f; // 뛰는 속도
    public float rotationSpeed = 7f;

    [Header("Character System")]
   
    public Animator animators; // 애니메이터

    
    private Rigidbody playerRigidbody; // Rigidbody

   
   

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        HandleMovement();
    }

   
    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

   
        Vector3 movement = new Vector3(xInput, 0,zInput).normalized;

        float currentSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? runSpeed : playerSpeed;

        playerRigidbody.velocity = new Vector3(movement.x * currentSpeed, playerRigidbody.velocity.y, movement.z * currentSpeed);

        if (animators != null)
        {
            bool isMoving = movement != Vector3.zero;
            animators.SetBool("IsWalk", isMoving && !Input.GetKey(KeyCode.LeftShift));
            animators.SetBool("IsRun", isMoving && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)));
        }

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

}
