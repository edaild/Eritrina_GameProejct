using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("ī�޶� ����")]
    public Camera thirdPersonCamera;  // 3��Ī ī�޶�
    public Transform target;           // ī�޶� ���� �÷��̾�

    public float cameraDistance = 3.0f;  // ī�޶� �Ÿ�
    public float minDistance = 1.0f;
    public float maxDistance = 3.0f;

    private float currentX = 0.0f;      // ���� ȸ�� ����
    private float currentY = 45.0f;     // ���� ȸ�� ����

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    public float mouseSensitivity = 200f;  // ���콺 ����

    public LayerMask collisionLayers;   // �浹�� ���̾� (��, ��ֹ� ��)

    void Start()
    {
        SetupCamera();
        Cursor.lockState = CursorLockMode.Locked;  // ���콺 Ŀ���� ���
    }

    void Update()
    {
        HandleInput();
        if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt)) // ALT Ű�� ������ �ʾ��� ���� ȸ��
        {
            HandleRotation();
        }
        HandleZoom();
    }

    private void HandleInput()
    {
        // ALT Ű�� ������ �� ���콺 Ŀ�� ǥ��
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            Cursor.lockState = CursorLockMode.None;  // ���콺 Ŀ�� ǥ��
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;  // ���콺 Ŀ�� ���
        }
    }

    public void HandleRotation()
    {
        // ���콺�� ī�޶��� ���� �� ���� ȸ�� ���� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentX += mouseX;
        currentY -= mouseY; // ���� �̵� �� ī�޶� �Ʒ���, �Ʒ��� �̵� �� ����
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        Vector3 direction = new Vector3(0, 0, -cameraDistance); // ī�޶� Ÿ���� ���ϴ� ����

        // ī�޶� ȸ�� ����
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0.0f);
        Vector3 desiredPosition = target.position + rotation * direction;

        // ī�޶�� Ÿ�� ���̿� Raycast�� ���� �ִ��� Ȯ��
        RaycastHit hit;
        if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, cameraDistance, collisionLayers))
        {
            // ���� �浹�ϸ� ī�޶� �� �������� �̵�
            thirdPersonCamera.transform.position = hit.point;
        }
        else
        {
            // �浹�� ������ ���� ���� ��ġ�� �̵�
            thirdPersonCamera.transform.position = desiredPosition;
        }

        thirdPersonCamera.transform.LookAt(target.position);  // Ÿ���� �ٶ�
    }

    public void HandleZoom()
    {
        // ���콺 �ٷ� ī�޶� �Ÿ� ����
        cameraDistance = Mathf.Clamp(cameraDistance - Input.GetAxis("Mouse ScrollWheel") * 5, minDistance, maxDistance);
    }

    void SetupCamera()
    {
        // �ʱ� ī�޶� ��ġ ����
        thirdPersonCamera.transform.position = target.position + new Vector3(0, 1.5f, -cameraDistance);
        thirdPersonCamera.transform.LookAt(target.position);  // Ÿ���� �ٶ󺸵��� �ʱ�ȭ
    }
}
