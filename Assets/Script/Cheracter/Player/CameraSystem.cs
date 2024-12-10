using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("카메라 설정")]
    public Camera thirdPersonCamera;  // 3인칭 카메라
    public Transform target;           // 카메라가 따라갈 플레이어

    public float cameraDistance = 3.0f;  // 카메라 거리
    public float minDistance = 1.0f;
    public float maxDistance = 3.0f;

    private float currentX = 0.0f;      // 수평 회전 각도
    private float currentY = 45.0f;     // 수직 회전 각도

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    public float mouseSensitivity = 200f;  // 마우스 감도

    public LayerMask collisionLayers;   // 충돌할 레이어 (벽, 장애물 등)

    void Start()
    {
        SetupCamera();
        Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서를 잠금
    }

    void Update()
    {
        HandleInput();
        if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt)) // ALT 키가 눌리지 않았을 때만 회전
        {
            HandleRotation();
        }
        HandleZoom();
    }

    private void HandleInput()
    {
        // ALT 키를 눌렀을 때 마우스 커서 표시
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            Cursor.lockState = CursorLockMode.None;  // 마우스 커서 표시
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서 잠금
        }
    }

    public void HandleRotation()
    {
        // 마우스로 카메라의 수평 및 수직 회전 각도 변경
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentX += mouseX;
        currentY -= mouseY; // 위로 이동 시 카메라가 아래로, 아래로 이동 시 위로
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        Vector3 direction = new Vector3(0, 0, -cameraDistance); // 카메라가 타겟을 향하는 방향

        // 카메라 회전 적용
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0.0f);
        Vector3 desiredPosition = target.position + rotation * direction;

        // 카메라와 타겟 사이에 Raycast로 벽이 있는지 확인
        RaycastHit hit;
        if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, cameraDistance, collisionLayers))
        {
            // 벽과 충돌하면 카메라를 그 지점으로 이동
            thirdPersonCamera.transform.position = hit.point;
        }
        else
        {
            // 충돌이 없으면 원래 계산된 위치로 이동
            thirdPersonCamera.transform.position = desiredPosition;
        }

        thirdPersonCamera.transform.LookAt(target.position);  // 타겟을 바라봄
    }

    public void HandleZoom()
    {
        // 마우스 휠로 카메라 거리 조정
        cameraDistance = Mathf.Clamp(cameraDistance - Input.GetAxis("Mouse ScrollWheel") * 5, minDistance, maxDistance);
    }

    void SetupCamera()
    {
        // 초기 카메라 위치 설정
        thirdPersonCamera.transform.position = target.position + new Vector3(0, 1.5f, -cameraDistance);
        thirdPersonCamera.transform.LookAt(target.position);  // 타겟을 바라보도록 초기화
    }
}
