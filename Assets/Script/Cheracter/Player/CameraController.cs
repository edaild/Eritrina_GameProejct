using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("카메라 따라갈 타켓")]
    public Transform target;         // 카메라가 따라갈 타겟
    public Vector3 offset;           // 타겟과의 오프셋

    [Header("카메라에 줌 제어")]
    public float zoomSpeed = 2f;     // 줌 속도
    public float distance =  2f;       // 타겟과의 초기 거리
    public float minDistance = 2f;    // 최소 거리
    public float maxDistance = 5f;    // 최대 거리

    [Header("카메라에 회전 제어")]
    public float rotateSpeed = 5.0f;  // 회전 속도
    public float limitAngle = 70.0f;  // 수직 회전의 제한 각도
    public float dragLimit = 5.0f;    // 드래그 제한 거리

    private bool isRotate;           // 카메라가 회전 중인지 여부
    private float mouseX;            // 마우스 X축 입력
    private float mouseY;            // 마우스 Y축 입력

    private Vector3 axisVec;         // 줌 계산을 위한 축 벡터
    private Transform mainCamera;    // 메인 카메라에 대한 참조

    private Vector3 lastMousePosition; // 마지막 마우스 위치

    void Start()
    {
        mainCamera = Camera.main.transform;  // 메인 카메라의 트랜스폼 가져오기
        UpdateCameraPosition(); // 초기 카메라 위치 설정
        lastMousePosition = Input.mousePosition; // 초기 마우스 위치 저장
    }

    void Update()
    {
        // 항상 타겟의 위치에 따라 카메라 위치 업데이트
        UpdateCameraPosition();
        Zoom();
        CameraRotate();
    }

    void UpdateCameraPosition()
    {
        // 타겟의 위치에 오프셋을 더하여 카메라 위치 설정
        transform.position = target.position + offset;
    }

    void Zoom()
    {
        // 마우스 스크롤 입력에 따라 줌 인/아웃
        distance += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1; // 거리 변경
        distance = Mathf.Clamp(distance, minDistance, maxDistance); // 거리를 최소 및 최대 값으로 클램프

        axisVec = transform.forward * -1 * distance; // 줌 벡터 계산
        mainCamera.position = transform.position + axisVec; // 카메라 위치 업데이트
    }

    void CameraRotate()
    {
        // 카메라 회전을 위한 마우스 버튼 입력 처리
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true; // 오른쪽 마우스 버튼 눌림
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false; // 오른쪽 마우스 버튼 떼짐
        }

        if (isRotate)
        {
            // 드래그 상태에서만 회전
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition; // 현재 마우스 위치와 마지막 위치의 차이
            if (mouseDelta.magnitude > dragLimit) // 드래그 제한
            {
                Rotation(mouseDelta);
            }
        }

        lastMousePosition = Input.mousePosition; // 마지막 마우스 위치 업데이트
    }

    public void Rotation(Vector3 mouseDelta)
    {
        // 마우스 이동량을 기반으로 회전 업데이트
        mouseX += mouseDelta.x * rotateSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY - mouseDelta.y * rotateSpeed * Time.deltaTime, -limitAngle, limitAngle); // Y축 회전 클램프

        // Y축 회전을 360도로 제한하기 위해 0에서 360도 사이로 유지
        mouseX = mouseX % 360; // mouseX를 360도로 나눈 나머지로 설정

        // 카메라에 회전 적용
        transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0.0f);
    }
}
