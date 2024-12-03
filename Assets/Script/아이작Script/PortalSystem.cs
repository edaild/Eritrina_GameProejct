using System.Collections;
using UnityEngine;

public class PortalSystem : MonoBehaviour
{
    public int EnemyCount = 0;
    public GameObject Camera;
    public GameObject[] PortarPoint;        // 포탈 포인트
    public GameObject[] CameraPoint;        // 카메라 포인트

    private Vector3 cameraVelocity = Vector3.zero; // 카메라 이동을 위한 속도 변수
    public float cameraSmoothTime = 0.3f; // 카메라 이동의 부드러움 조절

    private void OnTriggerEnter(Collider other)
    {
        // 1번방
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
        // 2번방
        if (other.CompareTag("Room02leftPortal"))
        {
            Debug.Log("왼쪽 룸으로 이동");
        }
        if (other.CompareTag("Room02rightPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[0].transform.position, CameraPoint[0].transform.position));
        }
        // 3번방
        if (other.CompareTag("Room03leftPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[1].transform.position, CameraPoint[0].transform.position));
        }
        if (other.CompareTag("Room03upPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[7].transform.position, CameraPoint[3].transform.position));
        }
        // 4번방
        if (other.CompareTag("Room04rightPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[8].transform.position, CameraPoint[4].transform.position));
        }
        if (other.CompareTag("Room04downPortal"))
        {
            StartCoroutine(MoveToPortal(PortarPoint[5].transform.position, CameraPoint[2].transform.position));
        }
        // 5번방
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
        // 포탈 이동
        transform.position = portalPosition;

        // 카메라의 부드러운 이동을 위한 보간
        float elapsedTime = 0f;
        Vector3 initialCameraPosition = Camera.transform.position;

        while (elapsedTime < cameraSmoothTime)
        {
            Camera.transform.position = Vector3.Lerp(initialCameraPosition, cameraPosition, elapsedTime / cameraSmoothTime);
            elapsedTime += Time.deltaTime;
            yield return null;  // 프레임마다 1번씩 실행
        }

        // 최종 카메라 위치 설정
        Camera.transform.position = cameraPosition;
    }
}
