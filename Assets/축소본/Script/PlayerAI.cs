using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public Animator animator;
    private bool isPlayerInRange = false;
    private Vector3 targetPosition;

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
        targetPosition = transform.position; // 초기 위치 설정
    }

    void Update()
    {
        if (!isPlayerInRange) // NPC 범위에 없을 때만 자동으로 앞으로 이동
        {
            // 목표 위치를 설정하고 부드럽게 이동
            targetPosition += -Vector3.forward * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            animator.SetBool("IsWorking", true); // 걷기 애니메이션 재생
        }
        else
        {
            animator.SetBool("IsWorking", false); // 애니메이션 멈춤
            // NPC와의 대화 시작 코드 (예: 대화 시작)
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPCtts"))
        {
            isPlayerInRange = true;
            // 대화나 이벤트 트리거 시작
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPCtts"))
        {
            isPlayerInRange = false;
        }
    }
}
