using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("ī�޶� ���� Ÿ��")]
    public Transform target;
    public Vector3 offset;

    [Header("ī�޶� �� ����")]
    public float zoomSpeed = 2f;
    public float distance = 2f;
    public float minDistance = 2f;
    public float maxDistance = 5f;

    [Header("ī�޶� ȸ�� ����")]
    public float rotateSpeed = 360f;
    public float limitAngle = 70.0f;   // ���� ȸ�� ����
    public float dragLimit = 5.0f;
    public float rotationSmoothTime = 0.1f; // ȸ�� �ε巴�� �ϴ� �ð�

    private bool isRotate;
    private float mouseX;
    private float mouseY;

    private Vector3 axisVec;
    private Transform mainCamera;
    private Vector3 lastMousePosition;
    private Quaternion targetRotation;       // ��ǥ ȸ��
    private Quaternion currentRotation;      // ���� ȸ��

    void Start()
    {
        mainCamera = Camera.main.transform;
        UpdateCameraPosition();
        lastMousePosition = Input.mousePosition;
        currentRotation = transform.rotation; // ���� ȸ�� �ʱ�ȭ
    }

    void Update()
    {
        UpdateCameraPosition();
        Zoom();
        CameraRotate();
    }

    void UpdateCameraPosition()
    {
        // ī�޶��� ��ǥ ��ġ ���
        Vector3 targetPosition = target.position + offset;

        // Raycasting�� ����Ͽ� ������ ���� Ȯ��
        RaycastHit hit;
        if (Physics.Raycast(targetPosition, Vector3.down, out hit))
        {
            targetPosition.y = Mathf.Max(targetPosition.y, hit.point.y + 0.5f);
        }

        // ī�޶� ��ġ ����
        transform.position = targetPosition;
    }

    void Zoom()
    {
        // ���콺 ��ũ�� �Է¿� ���� �� ��/�ƿ�
        distance += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        axisVec = transform.forward * -distance; // �� ���� ���
        mainCamera.position = transform.position + axisVec; // ī�޶� ��ġ ������Ʈ
    }

    void CameraRotate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
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
        mouseX += mouseDelta.x * rotateSpeed * 0.01f;
        mouseY = Mathf.Clamp(mouseY - mouseDelta.y * rotateSpeed * 0.01f, -limitAngle, limitAngle);
        mouseX = mouseX % 360;

        // ��ǥ ȸ�� ����
        targetRotation = Quaternion.Euler(-mouseY, mouseX, 0.0f);
        // �ε巴�� ȸ��
        currentRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime / rotationSmoothTime);
        // ȸ�� ����
        transform.rotation = currentRotation;
    }
}
