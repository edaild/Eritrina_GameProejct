using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaineQuest01 : MonoBehaviour
{
    [Header("NPC system")]
    public GameObject functionUI; // F Ű �ȳ� UI
    public Text functiontext; // F Ű �ȳ� �ؽ�Ʈ
    public GameObject textUI; // ��ȭ UI
    public Text npcName; // NPC �̸��� ǥ���� UI �ؽ�Ʈ
    public Text textObject; // ��ȭ ������ ǥ���� UI �ؽ�Ʈ
    public GameObject PlayerHpbar; // HP ��
    public GameObject menuButton; // �޴� ��ư

    public bool NpcCheck; // NPC���� ��ȭ ���� ����
    public int text_Count = 0; // ��ȭ ī��Ʈ
    public QuestManager questManager; // ����Ʈ �Ŵ��� ����
    public GameManger gameManger; // ���� �Ŵ��� ����

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
                npcName.text = "������ �ҳ�";
                textObject.text = "�� ȣ���� �հ��� ����� �־�";
                text_Count = 1;
            }
            else if (transform.CompareTag("NPC02"))
            {
                StartConversation();
                npcName.text = "ȣ�� ����";
                textObject.text = "����Ʈ���� ȣ�ڿ� ���Ű� ȯ���մϴ�.";
                text_Count = 1;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (transform.CompareTag("NPC01"))
            {
                HandleNpcDialogue(0); // NPC01 ��ȭ ó��
            }
            else if (transform.CompareTag("NPC02"))
            {
                HandleNpcDialogue(1); // NPC02 ��ȭ ó��
            }
        }
    }

    private void HandleNpcDialogue(int npcIndex)
    {
        if (npcIndex == 0 && gameManger.mainQuestCount == 0) // NPC01 ��ȭ
        {
            switch (text_Count)
            {
                case 1:
                    npcName.text = "����";
                    textObject.text = "��������?";
                    text_Count++;
                    break;
                case 2:
                    npcName.text = "�ڽ��� ȣ�� �����̶�� ������ �ҳ�";
                    textObject.text = "������ �̱���. �Ű澲�� ������ ��ſ� �޽� �Ǽ���.";
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
        else if (npcIndex == 1 && gameManger.mainQuestCount == 1) // NPC02 ��ȭ
        {
            switch (text_Count)
            {
                case 1:
                    textObject.text = "üũ���� ���͵帮�ڽ��ϴ�.";
                    text_Count++;
                    break;
                case 2:
                    textObject.text = "��ſ� �޽� �Ǽ���.";
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
            EndConversation(); // ��ȭ�� �ƴ� ��� ��ȭ ����
        }
    }

    // �÷��̾ NPC�� ������� �� ��ȭ ���� ���·� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NpcCheck = true;
            functionUI.SetActive(true);
        }
    }

    // �÷��̾ NPC���� �־��� �� ��ȭ ����
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndConversation();
        }
    }
}
