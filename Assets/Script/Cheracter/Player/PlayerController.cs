//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraSystem : MonoBehaviour
//{
//    [Header("카메라 설정")]
//    public Camera thirdPersonCamera;  // 3인칭 카메라

//    public float cameraDistance = 5.0f;  // 카메라 거리
//    public float minDistance = 1.0f;
//    public float maxDistance = 10.0f;

//    private float currentX = 0.0f;      // 수평 회전 각도
//    private float currentY = 45.0f;     // 수직 회전 각도

//    private const float Y_ANGLE_MIN = 0.0f;
//    private const float Y_ANGLE_MAX = 50.0f;
//    public float mouseSensitivity = 200f;  // 마우스 감도

//    void Start()
//    {
//        SetupCamera();
//        Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서를 잠금
//    }

//    void Update()
//    {
//        HandleRotation();
//    }

//    public void HandleRotation()
//    {
//        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

//        currentX += mouseX;
//        currentY -= mouseY;
//        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

//        Vector3 dir = new Vector3(0, 0, -cameraDistance);
//        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0.0f);
//        thirdPersonCamera.transform.position = transform.position + rotation * dir;
//        thirdPersonCamera.transform.LookAt(transform.position);

//        // 줌 처리
//        cameraDistance = Mathf.Clamp(cameraDistance - Input.GetAxis("Mouse ScrollWheel") * 5, minDistance, maxDistance);
//    }

//    void SetupCamera()
//    {
//        thirdPersonCamera.transform.position = transform.position + new Vector3(0, 1.5f, -cameraDistance);  // 초기 위치 설정
//    }
//}
