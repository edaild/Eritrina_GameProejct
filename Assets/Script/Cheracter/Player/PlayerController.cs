//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraSystem : MonoBehaviour
//{
//    [Header("ī�޶� ����")]
//    public Camera thirdPersonCamera;  // 3��Ī ī�޶�

//    public float cameraDistance = 5.0f;  // ī�޶� �Ÿ�
//    public float minDistance = 1.0f;
//    public float maxDistance = 10.0f;

//    private float currentX = 0.0f;      // ���� ȸ�� ����
//    private float currentY = 45.0f;     // ���� ȸ�� ����

//    private const float Y_ANGLE_MIN = 0.0f;
//    private const float Y_ANGLE_MAX = 50.0f;
//    public float mouseSensitivity = 200f;  // ���콺 ����

//    void Start()
//    {
//        SetupCamera();
//        Cursor.lockState = CursorLockMode.Locked;  // ���콺 Ŀ���� ���
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

//        // �� ó��
//        cameraDistance = Mathf.Clamp(cameraDistance - Input.GetAxis("Mouse ScrollWheel") * 5, minDistance, maxDistance);
//    }

//    void SetupCamera()
//    {
//        thirdPersonCamera.transform.position = transform.position + new Vector3(0, 1.5f, -cameraDistance);  // �ʱ� ��ġ ����
//    }
//}
