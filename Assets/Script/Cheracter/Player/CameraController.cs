using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("카메라 따라갈 타켓")]
    public Transform target;
    public Vector3 offset;

    [Header("카메라에 줌 제어")]
    public float zoomSpeed = 2f;
    public float distance = 2f;
    public float minDistance = 2f;
    public float maxDistance = 5f;

    [Header("카메라에 회전 제어")]
    public float rotateSpeed = 10f;
    public float limitAngle = 70.0f;   // 수직 회전 제한
    public float dragLimit = 5.0f;
    public float rotationSmoothTime = 0.1f; // 회전 부드럽게 하는 시간

    private bool isRotate;
    private float mouseX;
    private float mouseY;

    private Vector3 axisVec;
    private Transform mainCamera;
    private Vector3 lastMousePosition;
    private Quaternion targetRotation;       // 목표 회전
    private Quaternion currentRotation;      // 현재 회전

    public NpcCharacterController npccharacterController;
    public MaineQuest01 MaineQuest01;
    void Start()
    {
        mainCamera = Camera.main.transform;
        UpdateCameraPosition();
        lastMousePosition = Input.mousePosition;
        currentRotation = transform.rotation; // 현재 회전 초기화
        npccharacterController = GetComponent<NpcCharacterController>();
        MaineQuest01 = GetComponent<MaineQuest01>();
    }

    void Update()
    {
        UpdateCameraPosition();
        Zoom();
        CameraRotate();
    }

    void UpdateCameraPosition()
    {
        // 카메라의 목표 위치 계산
        Vector3 targetPosition = target.position + offset;

        // Raycasting을 사용하여 지면의 높이 확인
        RaycastHit hit;
        if (Physics.Raycast(targetPosition, Vector3.down, out hit))
        {
            targetPosition.y = Mathf.Max(targetPosition.y, hit.point.y + 0.5f);
        }

        // 카메라 위치 설정
        transform.position = targetPosition;
    }

    void Zoom()
    {
        // 마우스 스크롤 입력에 따라 줌 인/아웃
        distance += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        axisVec = transform.forward * -distance; // 줌 벡터 계산
        mainCamera.position = transform.position + axisVec; // 카메라 위치 업데이트
    }

    void CameraRotate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            isRotate = false;
        }
        else
        {
            isRotate = true;
        }

        if (isRotate)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            if (mouseDelta.magnitude > dragLimit)
            {
                Rotation(mouseDelta);
            }
        }

        lastMousePosition = Input.mousePosition;
    }

    public void Rotation(Vector3 mouseDelta)
    {
        mouseX += mouseDelta.x * rotateSpeed * 0.01f; // 0.01f로 조정하여 더 일관된 회전 속도 유지
        mouseY = Mathf.Clamp(mouseY - mouseDelta.y * rotateSpeed * 0.01f, -limitAngle, limitAngle); // Y축 회전 클램프
        // Y축 회전을 360도로 제한하기 위해 0에서 360도 사이로 유지
        mouseX = mouseX % 360; // mouseX를 360도로 나눈 나머지로 설정
        // 카메라에 회전 적용
        transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0.0f);
    }
}
