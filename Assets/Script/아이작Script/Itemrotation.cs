using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public ItemData itemData;  // ItemData�� �����ϴ� ����
    public PlayerController playerController;
    public float rotationSpeed = 2f;  // ȸ�� �ӵ�

    private void Start()
    {
        // �� ���� ItemData ������Ʈ�� ã�� �Ҵ�
        itemData = FindObjectOfType<ItemData>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        // �������� ȸ����Ű�� �ڵ�
        transform.Rotate(new Vector3(0,0, rotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� "Player" �±��� ���
        if (other.CompareTag("Player"))
        {
            // �������� "piece" �±��� �� pieceCheck Ȱ��ȭ
            if (CompareTag("piece"))
            {
                itemData.pieceCheck = true;  // ItemData���� pieceCheck�� true�� ����
                transform.gameObject.SetActive(false);  // ������ ��Ȱ��ȭ
            }
            // �������� "spammo" �±��� �� spammoCheck Ȱ��ȭ
            else if (CompareTag("spBullt"))
            {
                playerController.spammoCheck = true;
                transform.gameObject.SetActive(false);  // ������ ��Ȱ��ȭ
            }
            // �������� "medic" �±��� �� medicCheck Ȱ��ȭ
            else if (CompareTag("medic"))
            {
                itemData.medicCheck = true;
                transform.gameObject.SetActive(false);  // ������ ��Ȱ��ȭ
            }
        }
    }
}
