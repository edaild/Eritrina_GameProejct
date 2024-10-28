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
    public float rotateSpeed = 10f;
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

    public NpcCharacterController npccharacterController;
    public MaineQuest01 MaineQuest01;
    void Start()
    {
        mainCamera = Camera.main.transform;
        UpdateCameraPosition();
        lastMousePosition = Input.mousePosition;
        currentRotation = transform.rotation; // ���� ȸ�� �ʱ�ȭ
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
        mouseX += mouseDelta.x * rotateSpeed * 0.01f; // 0.01f�� �����Ͽ� �� �ϰ��� ȸ�� �ӵ� ����
        mouseY = Mathf.Clamp(mouseY - mouseDelta.y * rotateSpeed * 0.01f, -limitAngle, limitAngle); // Y�� ȸ�� Ŭ����
        // Y�� ȸ���� 360���� �����ϱ� ���� 0���� 360�� ���̷� ����
        mouseX = mouseX % 360; // mouseX�� 360���� ���� �������� ����
        // ī�޶� ȸ�� ����
        transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0.0f);
    }
}
