using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("ī�޶� ���� Ÿ��")]
    public Transform target;         // ī�޶� ���� Ÿ��
    public Vector3 offset;           // Ÿ�ٰ��� ������

    [Header("ī�޶� �� ����")]
    public float zoomSpeed = 2f;     // �� �ӵ�
    public float distance =  2f;       // Ÿ�ٰ��� �ʱ� �Ÿ�
    public float minDistance = 2f;    // �ּ� �Ÿ�
    public float maxDistance = 5f;    // �ִ� �Ÿ�

    [Header("ī�޶� ȸ�� ����")]
    public float rotateSpeed = 5.0f;  // ȸ�� �ӵ�
    public float limitAngle = 70.0f;  // ���� ȸ���� ���� ����
    public float dragLimit = 5.0f;    // �巡�� ���� �Ÿ�

    private bool isRotate;           // ī�޶� ȸ�� ������ ����
    private float mouseX;            // ���콺 X�� �Է�
    private float mouseY;            // ���콺 Y�� �Է�

    private Vector3 axisVec;         // �� ����� ���� �� ����
    private Transform mainCamera;    // ���� ī�޶� ���� ����

    private Vector3 lastMousePosition; // ������ ���콺 ��ġ

    void Start()
    {
        mainCamera = Camera.main.transform;  // ���� ī�޶��� Ʈ������ ��������
        UpdateCameraPosition(); // �ʱ� ī�޶� ��ġ ����
        lastMousePosition = Input.mousePosition; // �ʱ� ���콺 ��ġ ����
    }

    void Update()
    {
        // �׻� Ÿ���� ��ġ�� ���� ī�޶� ��ġ ������Ʈ
        UpdateCameraPosition();
        Zoom();
        CameraRotate();
    }

    void UpdateCameraPosition()
    {
        // Ÿ���� ��ġ�� �������� ���Ͽ� ī�޶� ��ġ ����
        transform.position = target.position + offset;
    }

    void Zoom()
    {
        // ���콺 ��ũ�� �Է¿� ���� �� ��/�ƿ�
        distance += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1; // �Ÿ� ����
        distance = Mathf.Clamp(distance, minDistance, maxDistance); // �Ÿ��� �ּ� �� �ִ� ������ Ŭ����

        axisVec = transform.forward * -1 * distance; // �� ���� ���
        mainCamera.position = transform.position + axisVec; // ī�޶� ��ġ ������Ʈ
    }

    void CameraRotate()
    {
        // ī�޶� ȸ���� ���� ���콺 ��ư �Է� ó��
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true; // ������ ���콺 ��ư ����
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false; // ������ ���콺 ��ư ����
        }

        if (isRotate)
        {
            // �巡�� ���¿����� ȸ��
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition; // ���� ���콺 ��ġ�� ������ ��ġ�� ����
            if (mouseDelta.magnitude > dragLimit) // �巡�� ����
            {
                Rotation(mouseDelta);
            }
        }

        lastMousePosition = Input.mousePosition; // ������ ���콺 ��ġ ������Ʈ
    }

    public void Rotation(Vector3 mouseDelta)
    {
        // ���콺 �̵����� ������� ȸ�� ������Ʈ
        mouseX += mouseDelta.x * rotateSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY - mouseDelta.y * rotateSpeed * Time.deltaTime, -limitAngle, limitAngle); // Y�� ȸ�� Ŭ����

        // Y�� ȸ���� 360���� �����ϱ� ���� 0���� 360�� ���̷� ����
        mouseX = mouseX % 360; // mouseX�� 360���� ���� �������� ����

        // ī�޶� ȸ�� ����
        transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0.0f);
    }
}
