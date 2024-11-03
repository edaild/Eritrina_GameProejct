using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologScript : MonoBehaviour
{
    [Header("Function UI")]
    public GameObject functionUI; // F Ű �ȳ� UI
    public Text functionText; // F Ű �ȳ� �ؽ�Ʈ

    [Header("Text UI")]
    public GameObject textUI; // �ؽ�Ʈ UI
    public Text npcName; // NPC �̸��� ǥ���� UI �ؽ�Ʈ
    public Text textObject; // ��ȭ ������ ǥ���� UI �ؽ�Ʈ

    [Header("Health Bar")]
    public GameObject playerHpBar;

    [Header("Menu Button")]
    public GameObject menuButton; // �޴� ��ư

    [Header("Bool")]
    public bool npcCheck;   // NPC üũ

    [Header("Managers")]
    public int textCount = 0; // ��ȭ ī��Ʈ
    public QuestManager01 questManager01; // ����Ʈ �Ŵ��� ����
    public GameManager gameManager; // ���� �Ŵ��� ����

    [Header("Player Buttons")]
    public GameObject[] playerCharacterButtonList = new GameObject[4];

    [Header("Dialogue Audio")]
    public AudioClip[] dialogueClips; // �� ��翡 �ش��ϴ� ����� Ŭ�� �迭
    private AudioSource audioSource;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        questManager01 = FindObjectOfType<QuestManager01>();
        audioSource = gameObject.AddComponent<AudioSource>();

        npcCheck = false;
    }

    private void Update()
    {
        CheckNpcCharacter();
    }

    private void StartConversation()
    {
        functionUI.SetActive(false);
        textUI.SetActive(true);
        playerHpBar.SetActive(false);
        menuButton.SetActive(false);
    }

    private void EndConversation()
    {
        textUI.SetActive(false);
        textCount = 0;
        npcCheck = false;
        playerHpBar.SetActive(true);
        functionUI.SetActive(true);
        menuButton.SetActive(true);
    }

    private void CheckNpcCharacter()
    {
        if (!npcCheck) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (transform.CompareTag("meruhan"))
            {
                StartConversation();
                npcName.text = "�޸���";
                textObject.text = "�Ͼ���� �Ͼ����!";
                PlayDialogue(0); // ù ��° ��� ����� ���
                textCount = 1;
            }
        }
        

        if (Input.GetMouseButtonDown(0) && transform.CompareTag("meruhan"))
        {
            HandleNpcDialogue(0);
        }
    }

    private void HandleNpcDialogue(int npcIndex)
    {
        if (npcIndex == 0 && gameManager.mainQuestCount == 0)
        {
            switch (textCount)
            {
                case 1:
                    npcName.text = "����";
                    textObject.text = "�� ������ �� �̷���?";
                    PlayDialogue(1);
                    textCount++;
                    break;
                case 2:
                    npcName.text = "�޸���";
                    textObject.text = "�� ����� �̹� ���۵Ǿ��� ������ ������� ������ �ı� �Ǿ���.";
                    PlayDialogue(2);
                    textCount++;
                    break;
                case 3:
                    npcName.text = "�޸���";
                    textObject.text = "���� ���� ���� �����ڴ� ��Ű� �� ���̿���.";
                    PlayDialogue(3);
                    textCount++;
                    break;
                case 4:
                    EndConversation();
                    questManager01.CompleteCurrentStep();
                    gameManager.mainQuestCount = 1;
                    break;
            }
        }
        if (npcIndex == 0 && gameManager.mainQuestCount != 0)
        {
            EndConversation();
        }
    }

    private void PlayDialogue(int index)
    {
        if (index >= 0 && index < dialogueClips.Length)
        {
            audioSource.clip = dialogueClips[index];
            audioSource.Play();
        }
    }
}
