using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaineQuest01 : MonoBehaviour
{
    public static MaineQuest01 Instance; // Singleton Instance

    [Header("NPC system")]
    public GameObject[] NpcCharacter; // NPC 캐릭터 배열

    public GameObject functionUI; // F 키 안내 UI
    public Text functiontext; // F 키 안내 텍스트
    public float NpcSpeed; // NPC 속도 (현재 사용되지 않음)

    public GameObject textUI; // 대화 UI
    public Text npcName; // NPC 이름을 표시할 UI 텍스트
    public Text textObject; // 대화 내용을 표시할 UI 텍스트
    public GameObject hpbar; // HP 바 (현재 비활성화)
    public GameObject menuButton; // 메뉴 버튼 (현재 비활성화)

    public bool NpcCheck; // NPC와의 대화 가능 여부
    public bool NpcTextcheck; // 대화 진행 상태 (현재 사용되지 않음)

    public int text_Count = 0; // 대화 카운트
    public int NpcQuestCount = 0; // 쿼스트 카운트

    public QuestManager questManager; // 퀘스트 매니저 참조
    public bool NPC = false;

    private void Awake()
    {
        // Singleton 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴하지 않음
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    private void Start()
    {
        NpcCheck = false; // 초기에는 대화 불가능 상태
        NpcTextcheck = false;
        textUI.SetActive(false); // 대화 UI 비활성화
        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        NpcCharacterCheck(); // NPC 대화 체크
    }

    private void NpcCharacterCheck()
    {
        if (NpcCheck) // NPC와 대화 가능 상태일 때
        {
            if (Input.GetKeyDown(KeyCode.F)) // F 키 입력 시
            {
                // 현재 오브젝트가 "NPC" 태그인 경우 대화 시작
                if (transform.CompareTag("NPC01") && text_Count == 0)
                {
                    functionUI.SetActive(false);                // F 키 안내 UI 비활성화
                    textUI.SetActive(true);                     // 대화 UI 활성화
                    hpbar.SetActive(false);                     // HP 바 비활성화
                    menuButton.SetActive(false);                // 메뉴 버튼 비활성화
                    npcName.text = "수상한 소녀";                     // NPC 이름 설정
                    textObject.text = "이 호텔은 먼가를 숨기고 있어";              // 첫 번째 대화 내용
                    text_Count = 1;                             // 대화 카운트 설정
                }
            }
            if (transform.CompareTag("NPC01") && Input.GetMouseButtonDown(0) && NpcQuestCount != 0)
            {
                if (text_Count == 1)
                {
                    textUI.SetActive(false);
                }
            }
            // CompareTag가 NPC이고 마우스 좌측 버튼을 눌렸을 경우
            if (transform.CompareTag("NPC01") && Input.GetMouseButtonDown(0) && NpcQuestCount == 0)
            {
                // 마우스 클릭으로 대화 진행
                if (text_Count == 1)
                {
                    textObject.text = "누구세요?";           // 두 번째 대화 내용
                    text_Count = 2;                                                     // 대화 카운트 증가
                }
                else if (text_Count == 2)
                {
                    textObject.text = "아 투숙객 이군요 즐거운 휴식 되세요.";                            // 세 번째 대화 내용
                    text_Count = 3;                                                     // 대화 카운트 증가
                }
                else if (text_Count == 3)
                {
                    textUI.SetActive(false);                                           // 모든 대화가 끝나면 UI 비활성화
                    text_Count = 0;                                                    // 대화 카운트 초기화
                    NpcCheck = false;                                                  // 대화 불가능으로 설정
                    hpbar.SetActive(true);                                             // Player HP 바 활성화
                    functionUI.SetActive(true);                                        // F 키 안내 UI 활성화
                    menuButton.SetActive(true);                                        // 메뉴 버튼 활성화

                    FindObjectOfType<QuestManager>().CompleteCurrentStep();           // 퀘스트 단계 완료
                    NpcQuestCount = 1;                                              // 쿼스트 단계를 다음 단계로 올린다.

                }
            }

            if (Input.GetKeyDown(KeyCode.F)) // F 키 입력 시
            {
                // 현재 오브젝트가 "NPC" 태그인 경우 대화 시작
                if (transform.CompareTag("NPC02") && text_Count == 0)
                {
                    functionUI.SetActive(false);                // F 키 안내 UI 비활성화
                    textUI.SetActive(true);                     // 대화 UI 활성화
                    hpbar.SetActive(false);                     // HP 바 비활성화
                    menuButton.SetActive(false);                // 메뉴 버튼 비활성화
                    npcName.text = "호텔 직원";                     // NPC 이름 설정
                    textObject.text = "에리트리나 호텔에 오신걸 환영합니다.";              // 첫 번째 대화 내용
                    text_Count = 1;                             // 대화 카운트 설정
                }
            }
            if (transform.CompareTag("NPC02") && Input.GetMouseButtonDown(0) && NpcQuestCount != 1)
            {
                if (text_Count == 1)
                {
                    textUI.SetActive(false);
                }
            }
            // CompareTag가 NPC이고 마우스 좌측 버튼을 눌렸을 경우
            if (transform.CompareTag("NPC01") && Input.GetMouseButtonDown(0) && NpcQuestCount == 1)
            {
                // 마우스 클릭으로 대화 진행
                if (text_Count == 1)
                {
                    textObject.text = "체크인을 도와드리겠습니다.";           // 두 번째 대화 내용
                    text_Count = 2;                                                     // 대화 카운트 증가
                }
                else if (text_Count == 2)
                {
                    textObject.text = "즐거운 휴식 되세요.";                            // 세 번째 대화 내용
                    text_Count = 3;                                                     // 대화 카운트 증가
                }
                else if (text_Count == 3)
                {
                    textUI.SetActive(false);                                           // 모든 대화가 끝나면 UI 비활성화
                    text_Count = 0;                                                    // 대화 카운트 초기화
                    NpcCheck = false;                                                  // 대화 불가능으로 설정
                    hpbar.SetActive(true);                                             // Player HP 바 활성화
                    functionUI.SetActive(true);                                        // F 키 안내 UI 활성화
                    menuButton.SetActive(true);                                        // 메뉴 버튼 활성화

                    FindObjectOfType<QuestManager>().CompleteCurrentStep();           // 퀘스트 단계 완료
                    NpcQuestCount = 2;                                              // 쿼스트 단계를 다음 단계로 올린다.

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
            functionUI.SetActive(true);                             // F 키 안내 UI 활성화
            functiontext.text = "대화   F";                         // 안내 텍스트 설정
            NpcCheck = true;                                        // NPC와의 대화 가능으로 설정           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player가 NPC의 범위를 벗어날 때
        if (other.CompareTag("Player"))
        {
            NpcCheck = false;                                   // 대화 불가능으로 설정
            textUI.SetActive(false);                            // 대화 UI 비활성화
            hpbar.SetActive(true);                              // Player HP 바 활성화
            functionUI.SetActive(false);                        // F 키 안내 UI 비활성화
            text_Count = 0;                                     // 대화 카운트 초기화
        }
    }
}
