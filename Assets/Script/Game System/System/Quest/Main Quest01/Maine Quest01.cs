using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaineQuest01 : MonoBehaviour
{
    public static MaineQuest01 Instance; // Singleton Instance

    [Header("NPC system")]
    public GameObject[] NpcCharacter; // NPC ĳ���� �迭

    public GameObject functionUI; // F Ű �ȳ� UI
    public Text functiontext; // F Ű �ȳ� �ؽ�Ʈ
    public float NpcSpeed; // NPC �ӵ� (���� ������ ����)

    public GameObject textUI; // ��ȭ UI
    public Text npcName; // NPC �̸��� ǥ���� UI �ؽ�Ʈ
    public Text textObject; // ��ȭ ������ ǥ���� UI �ؽ�Ʈ
    public GameObject hpbar; // HP �� (���� ��Ȱ��ȭ)
    public GameObject menuButton; // �޴� ��ư (���� ��Ȱ��ȭ)

    public bool NpcCheck; // NPC���� ��ȭ ���� ����
    public bool NpcTextcheck; // ��ȭ ���� ���� (���� ������ ����)

    public int text_Count = 0; // ��ȭ ī��Ʈ
    public int NpcQuestCount = 0; // ����Ʈ ī��Ʈ

    public QuestManager questManager; // ����Ʈ �Ŵ��� ����
    public bool NPC = false;

    private void Awake()
    {
        // Singleton ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }

    private void Start()
    {
        NpcCheck = false; // �ʱ⿡�� ��ȭ �Ұ��� ����
        NpcTextcheck = false;
        textUI.SetActive(false); // ��ȭ UI ��Ȱ��ȭ
        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        NpcCharacterCheck(); // NPC ��ȭ üũ
    }

    private void NpcCharacterCheck()
    {
        if (NpcCheck) // NPC�� ��ȭ ���� ������ ��
        {
            if (Input.GetKeyDown(KeyCode.F)) // F Ű �Է� ��
            {
                // ���� ������Ʈ�� "NPC" �±��� ��� ��ȭ ����
                if (transform.CompareTag("NPC01") && text_Count == 0)
                {
                    functionUI.SetActive(false);                // F Ű �ȳ� UI ��Ȱ��ȭ
                    textUI.SetActive(true);                     // ��ȭ UI Ȱ��ȭ
                    hpbar.SetActive(false);                     // HP �� ��Ȱ��ȭ
                    menuButton.SetActive(false);                // �޴� ��ư ��Ȱ��ȭ
                    npcName.text = "������ �ҳ�";                     // NPC �̸� ����
                    textObject.text = "�� ȣ���� �հ��� ����� �־�";              // ù ��° ��ȭ ����
                    text_Count = 1;                             // ��ȭ ī��Ʈ ����
                }
            }
            if (transform.CompareTag("NPC01") && Input.GetMouseButtonDown(0) && NpcQuestCount != 0)
            {
                if (text_Count == 1)
                {
                    textUI.SetActive(false);
                }
            }
            // CompareTag�� NPC�̰� ���콺 ���� ��ư�� ������ ���
            if (transform.CompareTag("NPC01") && Input.GetMouseButtonDown(0) && NpcQuestCount == 0)
            {
                // ���콺 Ŭ������ ��ȭ ����
                if (text_Count == 1)
                {
                    textObject.text = "��������?";           // �� ��° ��ȭ ����
                    text_Count = 2;                                                     // ��ȭ ī��Ʈ ����
                }
                else if (text_Count == 2)
                {
                    textObject.text = "�� ������ �̱��� ��ſ� �޽� �Ǽ���.";                            // �� ��° ��ȭ ����
                    text_Count = 3;                                                     // ��ȭ ī��Ʈ ����
                }
                else if (text_Count == 3)
                {
                    textUI.SetActive(false);                                           // ��� ��ȭ�� ������ UI ��Ȱ��ȭ
                    text_Count = 0;                                                    // ��ȭ ī��Ʈ �ʱ�ȭ
                    NpcCheck = false;                                                  // ��ȭ �Ұ������� ����
                    hpbar.SetActive(true);                                             // Player HP �� Ȱ��ȭ
                    functionUI.SetActive(true);                                        // F Ű �ȳ� UI Ȱ��ȭ
                    menuButton.SetActive(true);                                        // �޴� ��ư Ȱ��ȭ

                    FindObjectOfType<QuestManager>().CompleteCurrentStep();           // ����Ʈ �ܰ� �Ϸ�
                    NpcQuestCount = 1;                                              // ����Ʈ �ܰ踦 ���� �ܰ�� �ø���.

                }
            }

            if (Input.GetKeyDown(KeyCode.F)) // F Ű �Է� ��
            {
                // ���� ������Ʈ�� "NPC" �±��� ��� ��ȭ ����
                if (transform.CompareTag("NPC02") && text_Count == 0)
                {
                    functionUI.SetActive(false);                // F Ű �ȳ� UI ��Ȱ��ȭ
                    textUI.SetActive(true);                     // ��ȭ UI Ȱ��ȭ
                    hpbar.SetActive(false);                     // HP �� ��Ȱ��ȭ
                    menuButton.SetActive(false);                // �޴� ��ư ��Ȱ��ȭ
                    npcName.text = "ȣ�� ����";                     // NPC �̸� ����
                    textObject.text = "����Ʈ���� ȣ�ڿ� ���Ű� ȯ���մϴ�.";              // ù ��° ��ȭ ����
                    text_Count = 1;                             // ��ȭ ī��Ʈ ����
                }
            }
            if (transform.CompareTag("NPC02") && Input.GetMouseButtonDown(0) && NpcQuestCount != 1)
            {
                if (text_Count == 1)
                {
                    textUI.SetActive(false);
                }
            }
            // CompareTag�� NPC�̰� ���콺 ���� ��ư�� ������ ���
            if (transform.CompareTag("NPC01") && Input.GetMouseButtonDown(0) && NpcQuestCount == 1)
            {
                // ���콺 Ŭ������ ��ȭ ����
                if (text_Count == 1)
                {
                    textObject.text = "üũ���� ���͵帮�ڽ��ϴ�.";           // �� ��° ��ȭ ����
                    text_Count = 2;                                                     // ��ȭ ī��Ʈ ����
                }
                else if (text_Count == 2)
                {
                    textObject.text = "��ſ� �޽� �Ǽ���.";                            // �� ��° ��ȭ ����
                    text_Count = 3;                                                     // ��ȭ ī��Ʈ ����
                }
                else if (text_Count == 3)
                {
                    textUI.SetActive(false);                                           // ��� ��ȭ�� ������ UI ��Ȱ��ȭ
                    text_Count = 0;                                                    // ��ȭ ī��Ʈ �ʱ�ȭ
                    NpcCheck = false;                                                  // ��ȭ �Ұ������� ����
                    hpbar.SetActive(true);                                             // Player HP �� Ȱ��ȭ
                    functionUI.SetActive(true);                                        // F Ű �ȳ� UI Ȱ��ȭ
                    menuButton.SetActive(true);                                        // �޴� ��ư Ȱ��ȭ

                    FindObjectOfType<QuestManager>().CompleteCurrentStep();           // ����Ʈ �ܰ� �Ϸ�
                    NpcQuestCount = 2;                                              // ����Ʈ �ܰ踦 ���� �ܰ�� �ø���.

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player�� �浹 �� ��ȭ ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("��ȭ�� �Ϸ��� F Ű�� ��������");
            functionUI.SetActive(true);                             // F Ű �ȳ� UI Ȱ��ȭ
            functiontext.text = "��ȭ   F";                         // �ȳ� �ؽ�Ʈ ����
            NpcCheck = true;                                        // NPC���� ��ȭ �������� ����           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player�� NPC�� ������ ��� ��
        if (other.CompareTag("Player"))
        {
            NpcCheck = false;                                   // ��ȭ �Ұ������� ����
            textUI.SetActive(false);                            // ��ȭ UI ��Ȱ��ȭ
            hpbar.SetActive(true);                              // Player HP �� Ȱ��ȭ
            functionUI.SetActive(false);                        // F Ű �ȳ� UI ��Ȱ��ȭ
            text_Count = 0;                                     // ��ȭ ī��Ʈ �ʱ�ȭ
        }
    }
}
