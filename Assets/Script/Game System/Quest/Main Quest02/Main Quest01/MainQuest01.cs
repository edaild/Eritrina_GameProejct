//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class MainQuest01 : MonoBehaviour
//{
//    [Header("Function UI")]
//    public GameObject functionUI; // F 키 안내 UI
//    public Text functiontext; // F 키 안내 텍스트

//    [Header("TextUI")]
//    public GameObject textUI; // textUI
//    public Text npcName; // NPC 이름을 표시할 UI 텍스트
//    public Text textObject; // 대화 내용을 표시할 UI 텍스트

//    [Header("Health Bar")]
//    public GameObject PlayerHpbar;

//    [Header("MenuButton")]
//    public GameObject menuButton; // 메뉴 버튼

//    [Header("Bool")]
//    public bool NpcCheck;   // NPC 체크

//    [Header("매니저 참조")]
//    public int text_Count = 0; // 대화 카운트
//    public QuestManager questManager; // 퀘스트 매니저 참조
//    public GameManger gameManger; // 게임 매니저 참조

//    private void Start()
//    {
//        NpcCheck = false;   
//        questManager = FindObjectOfType<QuestManager>();
//        gameManger = FindObjectOfType<GameManger>();       
//    }

//    private void Update()
//    {
//        NpcCharacterCheck();
//    }

//    private void StartConversation()
//    {
//        functionUI.SetActive(false);
//        textUI.SetActive(true);
//        PlayerHpbar.SetActive(false);
//        menuButton.SetActive(false);
//    }

//    private void EndConversation()
//    {
//        textUI.SetActive(false);
//        text_Count = 0;
//        NpcCheck = false;
//        PlayerHpbar.SetActive(true);
//        functionUI.SetActive(true);
//        menuButton.SetActive(true);
//    }

//    private void NpcCharacterCheck()
//    {
//        if (!NpcCheck) return;

//        if (Input.GetKeyDown(KeyCode.F) && NpcCheck)
//        {
//            if (transform.CompareTag("smile lady"))
//            {
//                StartConversation();
//                npcName.text = "들떠있는 소녀";
//                textObject.text = "와~ 여기가 세상에서 가장 크다는 에리트리나 호텔?!";
//                text_Count = 1;
//            }
//            else if (transform.CompareTag("reception"))
//            {
//                StartConversation();
//                npcName.text = "리셉션";
//                textObject.text = "안녕하세요~! '에리트리나'호텔에 오신걸 환영합니다!";
//                text_Count = 1;
//            }
//        }

//        if (Input.GetMouseButtonDown(0))
//        {
//            if (transform.CompareTag("smile lady"))
//            {
//                HandleNpcDialogue(0); // 들떠있는 소녀 대화 처리
//            }
//            else if (transform.CompareTag("reception"))
//            {
//                HandleNpcDialogue(1); // reception 대화 처리
//            }
//        }
//    }

//    private void HandleNpcDialogue(int npcIndex)
//    {
//        if (npcIndex == 0 && gameManger.mainQuestCount == 0) // smile lady 대화
//        {
//            switch (text_Count)
//            {
//                case 1:
//                    npcName.text = "벨즈";
//                    textObject.text = "꼬마야 혼자왔어? 엄마는?";
//                    text_Count++;
//                    break;
//                case 2:
//                    npcName.text = "들떠있는 소녀";
//                    textObject.text = "아니에요! 부모님이랑 같이왔...";
//                    text_Count++;
//                    break;
//                case 3:
//                    npcName.text = "들떠있는 소녀";
//                    textObject.text = "어...길을 잃어버렸다..헤헤";
//                    text_Count++;
//                    break;

//                case 4:
//                    EndConversation();
//                    questManager.CompleteCurrentStep();
//                    gameManger.mainQuestCount = 1;
//                    break;
//                default:
//                    EndConversation();
//                    break;
//            }
//        }
//        else if (npcIndex == 1 && gameManger.mainQuestCount == 1) // reception 대화
//        {
//            switch (text_Count)
//            {
//                case 1:
//                    textObject.text = "저희 호텔에 처음 오시는건가요?";
//                    text_Count++;
//                    break;
//                case 2:
//                    npcName.text = "벨즈";
//                    textObject.text = "네, 5403호에 초대 받았었습니다.";
//                    text_Count++;
//                    break;
//                case 3:
//                    npcName.text = "리셉션";
//                    textObject.text = "넵! 잠시만 기다려주세요.";
//                    text_Count++;
//                    break;
//                case 4:
//                    npcName.text = "리셉션";
//                    textObject.text = ". . .";
//                    text_Count++;
//                    break;
//                case 5:
//                    npcName.text = "리셉션";
//                    textObject.text = "네 기다려주셔서 감사합니다. 먼저 이 카드키를 받아주세요.";
//                    text_Count++;
//                    break;
//                case 6:
//                    npcName.text = "리셉션";
//                    textObject.text = "객실에 들어가실때 카드키함에 넣으시면 객실 사용이 가능하십니다!";
//                    text_Count++;
//                    break;
//                case 7:
//                    npcName.text = "리셉션";
//                    textObject.text = "그리고 사용하시는 객실에는 태블릿이 하나 놓여져 있으실껍니다. 여러가지 호텔 서비스를 사용하실 수 있으니, 참고바랍니다!";
//                    text_Count++;
//                    break;
//                case 8:
//                    npcName.text = "벨즈";
//                    textObject.text = "네, 감사합니다.";
//                    text_Count++;
//                    break;
//                case 9:
//                    npcName.text = "리셉션";
//                    textObject.text = "저희 지배인님께 초대받아서 오셨죠? 오늘 밤에 저희 호텔 라운지에서 초대손님들을 대상으로 파티를 진행한다고 하셨습니다.";
//                    text_Count++;
//                    break;
//                case 10:
//                    npcName.text = "리셉션";
//                    textObject.text = "고객님께서는 저희 지배인님이 초대해주신 귀한 분이시니, 파티 시간에 맞춰서 라운지에서 즐거운 시간 보내시길 바랍니다!";
//                    text_Count++;
//                    break;
//                case 11:
//                    npcName.text = "벨즈";
//                    textObject.text = "오늘 파티가 있었군요...듣진 못했던거 같은데...아무튼 정말 감사합니다!";
//                    text_Count++;
//                    break;
//                case 12:
//                    npcName.text = "벨즈";
//                    textObject.text = "(객실로 이동해보자)";
//                    text_Count++;
//                    break;
//                case 13:
//                    EndConversation();
//                    questManager.CompleteCurrentStep();
//                    gameManger.mainQuestCount = 2;
//                    break;
//                default:
//                    EndConversation();
//                    break;
//            }
//        }
//        else
//        {
//            EndConversation(); // 대화가 아닌 경우 대화 종료
//        }
//    }
//}


