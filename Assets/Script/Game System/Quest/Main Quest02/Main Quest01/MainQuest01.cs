//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class MainQuest01 : MonoBehaviour
//{
//    [Header("Function UI")]
//    public GameObject functionUI; // F Ű �ȳ� UI
//    public Text functiontext; // F Ű �ȳ� �ؽ�Ʈ

//    [Header("TextUI")]
//    public GameObject textUI; // textUI
//    public Text npcName; // NPC �̸��� ǥ���� UI �ؽ�Ʈ
//    public Text textObject; // ��ȭ ������ ǥ���� UI �ؽ�Ʈ

//    [Header("Health Bar")]
//    public GameObject PlayerHpbar;

//    [Header("MenuButton")]
//    public GameObject menuButton; // �޴� ��ư

//    [Header("Bool")]
//    public bool NpcCheck;   // NPC üũ

//    [Header("�Ŵ��� ����")]
//    public int text_Count = 0; // ��ȭ ī��Ʈ
//    public QuestManager questManager; // ����Ʈ �Ŵ��� ����
//    public GameManger gameManger; // ���� �Ŵ��� ����

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
//                npcName.text = "�鶰�ִ� �ҳ�";
//                textObject.text = "��~ ���Ⱑ ���󿡼� ���� ũ�ٴ� ����Ʈ���� ȣ��?!";
//                text_Count = 1;
//            }
//            else if (transform.CompareTag("reception"))
//            {
//                StartConversation();
//                npcName.text = "������";
//                textObject.text = "�ȳ��ϼ���~! '����Ʈ����'ȣ�ڿ� ���Ű� ȯ���մϴ�!";
//                text_Count = 1;
//            }
//        }

//        if (Input.GetMouseButtonDown(0))
//        {
//            if (transform.CompareTag("smile lady"))
//            {
//                HandleNpcDialogue(0); // �鶰�ִ� �ҳ� ��ȭ ó��
//            }
//            else if (transform.CompareTag("reception"))
//            {
//                HandleNpcDialogue(1); // reception ��ȭ ó��
//            }
//        }
//    }

//    private void HandleNpcDialogue(int npcIndex)
//    {
//        if (npcIndex == 0 && gameManger.mainQuestCount == 0) // smile lady ��ȭ
//        {
//            switch (text_Count)
//            {
//                case 1:
//                    npcName.text = "����";
//                    textObject.text = "������ ȥ�ڿԾ�? ������?";
//                    text_Count++;
//                    break;
//                case 2:
//                    npcName.text = "�鶰�ִ� �ҳ�";
//                    textObject.text = "�ƴϿ���! �θ���̶� ���̿�...";
//                    text_Count++;
//                    break;
//                case 3:
//                    npcName.text = "�鶰�ִ� �ҳ�";
//                    textObject.text = "��...���� �Ҿ���ȴ�..����";
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
//        else if (npcIndex == 1 && gameManger.mainQuestCount == 1) // reception ��ȭ
//        {
//            switch (text_Count)
//            {
//                case 1:
//                    textObject.text = "���� ȣ�ڿ� ó�� ���ô°ǰ���?";
//                    text_Count++;
//                    break;
//                case 2:
//                    npcName.text = "����";
//                    textObject.text = "��, 5403ȣ�� �ʴ� �޾Ҿ����ϴ�.";
//                    text_Count++;
//                    break;
//                case 3:
//                    npcName.text = "������";
//                    textObject.text = "��! ��ø� ��ٷ��ּ���.";
//                    text_Count++;
//                    break;
//                case 4:
//                    npcName.text = "������";
//                    textObject.text = ". . .";
//                    text_Count++;
//                    break;
//                case 5:
//                    npcName.text = "������";
//                    textObject.text = "�� ��ٷ��ּż� �����մϴ�. ���� �� ī��Ű�� �޾��ּ���.";
//                    text_Count++;
//                    break;
//                case 6:
//                    npcName.text = "������";
//                    textObject.text = "���ǿ� ���Ƕ� ī��Ű�Կ� �����ø� ���� ����� �����Ͻʴϴ�!";
//                    text_Count++;
//                    break;
//                case 7:
//                    npcName.text = "������";
//                    textObject.text = "�׸��� ����Ͻô� ���ǿ��� �º��� �ϳ� ������ �����ǲ��ϴ�. �������� ȣ�� ���񽺸� ����Ͻ� �� ������, ����ٶ��ϴ�!";
//                    text_Count++;
//                    break;
//                case 8:
//                    npcName.text = "����";
//                    textObject.text = "��, �����մϴ�.";
//                    text_Count++;
//                    break;
//                case 9:
//                    npcName.text = "������";
//                    textObject.text = "���� �����δԲ� �ʴ�޾Ƽ� ������? ���� �㿡 ���� ȣ�� ��������� �ʴ�մԵ��� ������� ��Ƽ�� �����Ѵٰ� �ϼ̽��ϴ�.";
//                    text_Count++;
//                    break;
//                case 10:
//                    npcName.text = "������";
//                    textObject.text = "���Բ����� ���� �����δ��� �ʴ����ֽ� ���� ���̽ô�, ��Ƽ �ð��� ���缭 ��������� ��ſ� �ð� �����ñ� �ٶ��ϴ�!";
//                    text_Count++;
//                    break;
//                case 11:
//                    npcName.text = "����";
//                    textObject.text = "���� ��Ƽ�� �־�����...���� ���ߴ��� ������...�ƹ�ư ���� �����մϴ�!";
//                    text_Count++;
//                    break;
//                case 12:
//                    npcName.text = "����";
//                    textObject.text = "(���Ƿ� �̵��غ���)";
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
//            EndConversation(); // ��ȭ�� �ƴ� ��� ��ȭ ����
//        }
//    }
//}


