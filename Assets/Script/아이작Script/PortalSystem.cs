using System.Collections;
using UnityEngine;

public class PortalSystem : MonoBehaviour
{
    public int EnemyCount = 0;
    public GameObject Camera;
    public GameObject[] PortarPoint;        // ��Ż ����Ʈ
    public GameObject[] CameraPoint;        // ī�޶� ����Ʈ

    private Vector3 cameraVelocity = Vector3.zero; // ī�޶� �̵��� ���� �ӵ� ����
    public float cameraSmoothTime = 0.3f; // ī�޶� �̵��� �ε巯�� ����

    private void OnTriggerEnter(Collider other)
    {
        // 1����
        if (other.CompareTag("Room01leftPortal"))
        {
            if (EnemyCount >= 2)
            {
                StartCoroutine(MoveToPortal(PortarPoint[3].transform.position, CameraPoint[1].transform.position));
            }
        }
        if (other.CompareTag("Room01rightPortal"))
        {
            if (EnemyCount >= 2)
            {
                StartCoroutine(MoveToPortal(PortarPoint[4].transform.position, CameraPoint[2].transform.position));
            }
        }
        // 2����
        if (other.CompareTag("Room02leftPortal"))
        {
            Debug.Log("���� ������ �̵�");
        }
        if (other.CompareTag("Room02rightPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[0].transform.position, CameraPoint[0].transform.position));
        }
        // 3����
        if (other.CompareTag("Room03leftPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[1].transform.position, CameraPoint[0].transform.position));
        }
        if (other.CompareTag("Room03upPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[7].transform.position, CameraPoint[3].transform.position));
        }
        // 4����
        if (other.CompareTag("Room04rightPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[8].transform.position, CameraPoint[4].transform.position));
        }
        if (other.CompareTag("Room04downPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[5].transform.position, CameraPoint[2].transform.position));
        }
        // 5����
        if (other.CompareTag("Room05leftPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[5].transform.position, CameraPoint[3].transform.position));
        }
        if (other.CompareTag("Room05rightPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[10].transform.position, CameraPoint[5].transform.position));
        }

    }

    private IEnumerator MoveToPortal(Vector3 portalPosition, Vector3 cameraPosition)
    {
        // ��Ż �̵�
        transform.position = portalPosition;

        // ī�޶��� �ε巯�� �̵��� ���� ����
        float elapsedTime = 0f;
        Vector3 initialCameraPosition = Camera.transform.position;

        while (elapsedTime < cameraSmoothTime)
        {
            Camera.transform.position = Vector3.Lerp(initialCameraPosition, cameraPosition, elapsedTime / cameraSmoothTime);
            elapsedTime += Time.deltaTime;
            yield return null;  // �����Ӹ��� 1���� ����
        }

        // ���� ī�޶� ��ġ ����
        Camera.transform.position = cameraPosition;
    }
}
