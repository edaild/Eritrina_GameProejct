using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public ItemData itemData;  // ItemData를 참조하는 변수
    public PlayerController playerController;
    public float rotationSpeed = 2f;  // 회전 속도

    private void Start()
    {
        // 씬 내의 ItemData 컴포넌트를 찾아 할당
        itemData = FindObjectOfType<ItemData>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        // 아이템을 회전시키는 코드
        transform.Rotate(new Vector3(0,0, rotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 "Player" 태그일 경우
        if (other.CompareTag("Player"))
        {
            // 아이템이 "piece" 태그일 때 pieceCheck 활성화
            if (CompareTag("piece"))
            {
                itemData.pieceCheck = true;  // ItemData에서 pieceCheck를 true로 설정
                transform.gameObject.SetActive(false);  // 아이템 비활성화
            }
            // 아이템이 "spammo" 태그일 때 spammoCheck 활성화
            else if (CompareTag("spBullt"))
            {
                playerController.spammoCheck = true;
                transform.gameObject.SetActive(false);  // 아이템 비활성화
            }
            // 아이템이 "medic" 태그일 때 medicCheck 활성화
            else if (CompareTag("medic"))
            {
                itemData.medicCheck = true;
                transform.gameObject.SetActive(false);  // 아이템 비활성화
            }
        }
    }
}
