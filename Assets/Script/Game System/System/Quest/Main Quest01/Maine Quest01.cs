using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaineQuest01 : MonoBehaviour
{
    [Header("NPC system")]
    public GameObject functionUI; // F 키 안내 UI
    public Text functiontext; // F 키 안내 텍스트
    public GameObject textUI; // 대화 UI
    public Text npcName; // NPC 이름을 표시할 UI 텍스트
    public Text textObject; // 대화 내용을 표시할 UI 텍스트
    public GameObject PlayerHpbar; // HP 바
    public GameObject menuButton; // 메뉴 버튼

    public bool NpcCheck; // NPC와의 대화 가능 여부
    public int text_Count = 0; // 대화 카운트
    public QuestManager questManager; // 퀘스트 매니저 참조
    public GameManger gameManger; // 게임 매니저 참조

    private void Start()
    {
        NpcCheck = false;
        textUI.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
        gameManger = FindObjectOfType<GameManger>();
    }

    private void Update()
    {
        NpcCharacterCheck();
    }

    private void StartConversation()
    {
        functionUI.SetActive(false);
        textUI.SetActive(true);
        PlayerHpbar.SetActive(false);
        menuButton.SetActive(false);
    }

    private void EndConversation()
    {
        textUI.SetActive(false);
        text_Count = 0;
        NpcCheck = false;
        PlayerHpbar.SetActive(true);
        functionUI.SetActive(true);
        menuButton.SetActive(true);
    }

    private void NpcCharacterCheck()
    {
        if (!NpcCheck) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (transform.CompareTag("NPC01"))
            {
                StartConversation();
                npcName.text = "수상한 소녀";
                textObject.text = "이 호텔은 먼가를 숨기고 있어";
                text_Count = 1;
            }
            else if (transform.CompareTag("NPC02"))
            {
                StartConversation();
                npcName.text = "호텔 직원";
                textObject.text = "에리트리나 호텔에 오신걸 환영합니다.";
                text_Count = 1;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (transform.CompareTag("NPC01"))
            {
                HandleNpcDialogue(0); // NPC01 대화 처리
            }
            else if (transform.CompareTag("NPC02"))
            {
                HandleNpcDialogue(1); // NPC02 대화 처리
            }
        }
    }

    private void HandleNpcDialogue(int npcIndex)
    {
        if (npcIndex == 0 && gameManger.mainQuestCount == 0) // NPC01 대화
        {
            switch (text_Count)
            {
                case 1:
                    npcName.text = "벨즈";
                    textObject.text = "누구세요?";
                    text_Count++;
                    break;
                case 2:
                    npcName.text = "자신을 호텔 직원이라고 밝히는 소녀";
                    textObject.text = "투숙객 이군요. 신경쓰지 마세요 즐거운 휴식 되세요.";
                    text_Count++;
                    break;
                case 3:
                    EndConversation();
                    questManager.CompleteCurrentStep();
                    gameManger.mainQuestCount = 1;
                    break;
                default:
                    EndConversation();
                    break;
            }
        }
        else if (npcIndex == 1 && gameManger.mainQuestCount == 1) // NPC02 대화
        {
            switch (text_Count)
            {
                case 1:
                    textObject.text = "체크인을 도와드리겠습니다.";
                    text_Count++;
                    break;
                case 2:
                    textObject.text = "즐거운 휴식 되세요.";
                    text_Count++;
                    break;
                case 3:
                    EndConversation();
                    questManager.CompleteCurrentStep();
                    gameManger.mainQuestCount = 2;
                    break;
                default:
                    EndConversation();
                    break;
            }
        }
        else
        {
            EndConversation(); // 대화가 아닌 경우 대화 종료
        }
    }

    // 플레이어가 NPC와 가까워질 때 대화 가능 상태로 변경
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NpcCheck = true;
            functionUI.SetActive(true);
        }
    }

    // 플레이어가 NPC에서 멀어질 때 대화 종료
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndConversation();
        }
    }
}
