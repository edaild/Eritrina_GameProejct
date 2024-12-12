using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalSystem : MonoBehaviour
{
    public int EnemyCount = 0;
    public GameObject Camera;
    public GameObject[] PortarPoint;        // 포탈 포인트
    public GameObject[] CameraPoint;        // 카메라 포인트

    public ItemData item;
    public UIData uIData;

    private Vector3 cameraVelocity = Vector3.zero; // 카메라 이동을 위한 속도 변수
    public float cameraSmoothTime = 0.3f; // 카메라 이동의 부드러움 조절

    private void Start()
    {
        item = FindObjectOfType<ItemData>();
        uIData = FindObjectOfType<UIData>();
    }
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(MoveToPortal(PortarPoint[3].transform.position, CameraPoint[1].transform.position));
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine(MoveToPortal(PortarPoint[10].transform.position, CameraPoint[5].transform.position));
        }
    }



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
            if (item.pieceCount >= 4)
            {
                SceneManager.LoadScene("FinishScene");
                Debug.Log("씬 이동");
            }
            
        }
        if (other.CompareTag("Room02rightPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[0].transform.position, CameraPoint[0].transform.position));
            }
        }

        if (other.CompareTag("Room02upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[32].transform.position, CameraPoint[16].transform.position));
            }
        }

        if (other.CompareTag("Room02downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[42].transform.position, CameraPoint[21].transform.position));
            }
        }



        // 3번방
        if (other.CompareTag("Room03leftPortal"))
        {
            if (EnemyCount >= 5)
            {
                StartCoroutine(MoveToPortal(PortarPoint[1].transform.position, CameraPoint[0].transform.position));
            }
        }
        if (other.CompareTag("Room03upPortal"))
        {
            if (EnemyCount >= 5)
            {
                StartCoroutine(MoveToPortal(PortarPoint[7].transform.position, CameraPoint[3].transform.position));
            }
        }
        // 4번방
        if (other.CompareTag("Room04rightPortal"))
        {
            if (EnemyCount >= 9)
            {
                StartCoroutine(MoveToPortal(PortarPoint[8].transform.position, CameraPoint[4].transform.position));
            }
        }
        if (other.CompareTag("Room04downPortal"))
        {
            if (EnemyCount >= 9)
            {
                StartCoroutine(MoveToPortal(PortarPoint[5].transform.position, CameraPoint[2].transform.position));
            }
        }
        // 5번방
        if (other.CompareTag("Room05leftPortal"))
        {
            if (EnemyCount >= 10)
            {
                StartCoroutine(MoveToPortal(PortarPoint[6].transform.position, CameraPoint[3].transform.position));
            }
        }
        if (other.CompareTag("Room05rightPortal"))
        {
            if (EnemyCount >= 10)
            {
                StartCoroutine(MoveToPortal(PortarPoint[10].transform.position, CameraPoint[5].transform.position));
            }
        }

        // 6번방
        if (other.CompareTag("Room06leftPortal"))
        {
            if (EnemyCount >= 14)
            {
                StartCoroutine(MoveToPortal(PortarPoint[9].transform.position, CameraPoint[4].transform.position));
            }
        }
        if (other.CompareTag("Room06upPortal"))
        {
            if (EnemyCount >= 14)
            {
                StartCoroutine(MoveToPortal(PortarPoint[14].transform.position, CameraPoint[6].transform.position));
            }
        }
        if (other.CompareTag("Room06downPortal")) // 12번 방으로 이동
        {
            if (EnemyCount >= 30)
            {
                StartCoroutine(MoveToPortal(PortarPoint[22].transform.position, CameraPoint[11].transform.position));
            }
        }

        // 7 번방
        if (other.CompareTag("Room07upPortal"))
        {
            if (EnemyCount >= 19)
            {
                StartCoroutine(MoveToPortal(PortarPoint[16].transform.position, CameraPoint[7].transform.position));
            }
        }
        if (other.CompareTag("Room07downPortal")) 
        {
            if (EnemyCount >= 19)
            {
                StartCoroutine(MoveToPortal(PortarPoint[11].transform.position, CameraPoint[5].transform.position));
            }
        }

        // 8 번방
        if (other.CompareTag("Room08upPortal"))
        {
            if (EnemyCount >= 23)
            {
                StartCoroutine(MoveToPortal(PortarPoint[18].transform.position, CameraPoint[8].transform.position));
            }
        }
        if (other.CompareTag("Room08downPortal"))
        {
            if (EnemyCount >= 23)
            {
                StartCoroutine(MoveToPortal(PortarPoint[13].transform.position, CameraPoint[6].transform.position));
            }
        }

        // 9 번방
        if (other.CompareTag("Room09upPortal"))
        {
            if (EnemyCount >= 27)
            {
                StartCoroutine(MoveToPortal(PortarPoint[20].transform.position, CameraPoint[9].transform.position));
            }
        }
        if (other.CompareTag("Room09downPortal"))
        {
            if (EnemyCount >= 27)
            {
                StartCoroutine(MoveToPortal(PortarPoint[15].transform.position, CameraPoint[7].transform.position));
            }
        }

        // 10 번방
        if (other.CompareTag("Room10upPortal"))
        {
            if (EnemyCount >= 29)
            {
                StartCoroutine(MoveToPortal(PortarPoint[21].transform.position, CameraPoint[10].transform.position));
            }
        }
        if (other.CompareTag("Room10downPortal"))
        {
            if (EnemyCount >= 29)
            {
                StartCoroutine(MoveToPortal(PortarPoint[17].transform.position, CameraPoint[8].transform.position));
            }
        }

        // 11 번방
        if (other.CompareTag("Room11downPortal"))
        {
            if (EnemyCount >= 30)
            {
                StartCoroutine(MoveToPortal(PortarPoint[19].transform.position, CameraPoint[9].transform.position));
            }
        }

        // 12 번방
        if (other.CompareTag("Room12upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[12].transform.position, CameraPoint[5].transform.position));
            }
        }
        if (other.CompareTag("Room12downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[24].transform.position, CameraPoint[12].transform.position));
            }
        }

        // 13 번방
        if (other.CompareTag("Room13upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[23].transform.position, CameraPoint[11].transform.position));
            }
        }
        if (other.CompareTag("Room13downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[26].transform.position, CameraPoint[13].transform.position));
            }
        }

        // 14 번방
        if (other.CompareTag("Room14upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[25].transform.position, CameraPoint[12].transform.position));
            }
        }
        if (other.CompareTag("Room14downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[28].transform.position, CameraPoint[14].transform.position));
            }
        }

        // 15 번방
        if (other.CompareTag("Room15upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[27].transform.position, CameraPoint[13].transform.position));
            }
        }
        if (other.CompareTag("Room15downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[30].transform.position, CameraPoint[15].transform.position));
            }
        }

        // 16 번방

        if (other.CompareTag("Room16dupPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[29].transform.position, CameraPoint[14].transform.position));
            }
        }

        // 17 번방
        if (other.CompareTag("Room17upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[34].transform.position, CameraPoint[17].transform.position));
            }
        }
        if (other.CompareTag("Room17downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[40].transform.position, CameraPoint[1].transform.position));
            }
        }

        // 18 번방
        if (other.CompareTag("Room18upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[36].transform.position, CameraPoint[18].transform.position));
            }
        }
        if (other.CompareTag("Room18downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[31].transform.position, CameraPoint[16].transform.position));
            }
        }

        // 19 번방
        if (other.CompareTag("Room19upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[38].transform.position, CameraPoint[19].transform.position));
            }
        }
        if (other.CompareTag("Room19downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[33].transform.position, CameraPoint[17].transform.position));
            }
        }

        // 20 번방
        if (other.CompareTag("Room20upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[39].transform.position, CameraPoint[20].transform.position));
            }
        }
        if (other.CompareTag("Room20downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[35].transform.position, CameraPoint[18].transform.position));
            }
        }

        // 21 번방
        if (other.CompareTag("Room21downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[37].transform.position, CameraPoint[19].transform.position));
            }
        }


        // 22 번방
        if (other.CompareTag("Room22upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[41].transform.position, CameraPoint[1].transform.position));
            }
        }
        if (other.CompareTag("Room22downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[44].transform.position, CameraPoint[22].transform.position));
            }
        }

        // 23 번방
        if (other.CompareTag("Room23upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[43].transform.position, CameraPoint[21].transform.position));
            }
        }
        if (other.CompareTag("Room23downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[46].transform.position, CameraPoint[23].transform.position));
            }
        }

        // 24 번방
        if (other.CompareTag("Room24upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[45].transform.position, CameraPoint[22].transform.position));
            }
        }
        if (other.CompareTag("Room24downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[48].transform.position, CameraPoint[24].transform.position));
            }
        }

        // 25 번방
        if (other.CompareTag("Room25upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[47].transform.position, CameraPoint[23].transform.position));
            }
        }
        if (other.CompareTag("Room25downPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[50].transform.position, CameraPoint[25].transform.position));
            }
        }

        // 26 번방
        if (other.CompareTag("Room26upPortal"))
        {
            if (EnemyCount >= 0)
            {
                StartCoroutine(MoveToPortal(PortarPoint[49].transform.position, CameraPoint[24].transform.position));
            }
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
