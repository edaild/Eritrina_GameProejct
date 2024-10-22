using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcCharacterController : MonoBehaviour
{
    [Header("NPC system")]
    public GameObject[] NpcCharacter; // NPC 캐릭터 배열

    public GameObject functionUI; // F 키 안내 UI
    public Text functiontext;
    public float NpcSpeed; // NPC 속도 (현재 사용되지 않음)

    public GameObject textUI; // 대화 UI
    public Text npcName; // NPC 이름을 표시할 UI 텍스트
    public Text textObject; // 대화 내용을 표시할 UI 텍스트
    public GameObject npcImags; // NPC 이미지 (현재 사용되지 않음)
    public GameObject hpbar; // HP 바 (현재 비활성화)
    public GameObject menuButton; // 메뉴 버튼 (현재 비활성화)

    public int text_Count = 0; // 대화 카운트

    public bool NpcCheck; // NPC와의 대화 가능 여부

    private void Start()
    {
        NpcCheck = false; // 초기에는 대화 불가능 상태
        textUI.SetActive(false); // 대화 UI 비활성화
    }

    private void Update()
    {
        if (NpcCheck)
        {
            // FKeyUI.SetActive(true); // F 키 안내 UI 활성화
            if (Input.GetKeyDown(KeyCode.F))
            {
                // 현재 오브젝트가 "NPC" 태그인 경우 대화 시작
                if (transform.CompareTag("NPC") && text_Count == 0)
                {
                    functionUI.SetActive(false);
                    textUI.SetActive(true); // 대화 UI 활성화
                    hpbar.SetActive(false); // HP 바 비활성화
                    menuButton.SetActive(false); // 메뉴 버튼 비활성화
                    functionUI.SetActive(false);
                    npcName.text = "아이"; // NPC 이름 설정
                    textObject.text = "안녕하세요."; // 첫 번째 대화 내용
                    text_Count = 1; // 대화 카운트 설정

                }
            }
            // CompareTag 가 NPC 이고 마우스 좌측 버튼을 눌렸을 경우
            if ((transform.CompareTag("NPC") && Input.GetMouseButtonDown(0)))
            {
                // 마우스 클릭으로 대화 진행
                if (text_Count == 1)
                {
                    textObject.text = "에리트리나 호텔에 오신걸 환영합니다."; // 두 번째 대화 내용
                    text_Count = 2; // 대화 카운트 증가
                }
                else if (text_Count == 2)
                {
                    textObject.text = "즐거운 휴식 되세요."; // 세 번째 대화 내용
                    text_Count = 3; // 대화 카운트 증가
                }
                else if (text_Count == 3)
                {
                    textUI.SetActive(false); // 모든 대화가 끝나면 UI 비활성화
                    text_Count = 0; // 대화 카운트 초기화
                    NpcCheck = false; // 대화 불가능으로 설정
                    hpbar.SetActive(true); // player HP 바 활성화
                    functionUI.SetActive(true);
                    menuButton.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player와 충돌 시 대화 가능
        if (other.CompareTag("Player"))
        {
            Debug.Log("대화를 하려면 F 키를 누르세요");
            functionUI.SetActive(true);
            functiontext.text = "대화   F";
            NpcCheck = true; // NPC와의 대화 가능으로 설정
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player가 NPC의 범위를 벗어날 때
        if (other.CompareTag("Player"))
        {
            NpcCheck = false; // 대화 불가능으로 설정
            textUI.SetActive(false); // 대화 UI 비활성화
            hpbar.SetActive(true); // Player Hp바를 활성화
            functionUI.SetActive(false);
            text_Count = 0; // 대화 카운트 초기화
        }
    }
}
