using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public Animator animator;
    private bool isPlayerInRange = false;
    private Vector3 targetPosition;

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
        targetPosition = transform.position; // �ʱ� ��ġ ����
    }

    void Update()
    {
        if (!isPlayerInRange) // NPC ������ ���� ���� �ڵ����� ������ �̵�
        {
            // ��ǥ ��ġ�� �����ϰ� �ε巴�� �̵�
            targetPosition += -Vector3.forward * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            animator.SetBool("IsWorking", true); // �ȱ� �ִϸ��̼� ���
        }
        else
        {
            animator.SetBool("IsWorking", false); // �ִϸ��̼� ����
            // NPC���� ��ȭ ���� �ڵ� (��: ��ȭ ����)
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPCtts"))
        {
            isPlayerInRange = true;
            // ��ȭ�� �̺�Ʈ Ʈ���� ����
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
