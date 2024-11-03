using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologScript : MonoBehaviour
{
    [Header("Function UI")]
    public GameObject functionUI; // F 키 안내 UI
    public Text functionText; // F 키 안내 텍스트

    [Header("Text UI")]
    public GameObject textUI; // 텍스트 UI
    public Text npcName; // NPC 이름을 표시할 UI 텍스트
    public Text textObject; // 대화 내용을 표시할 UI 텍스트

    [Header("Health Bar")]
    public GameObject playerHpBar;

    [Header("Menu Button")]
    public GameObject menuButton; // 메뉴 버튼

    [Header("Bool")]
    public bool npcCheck;   // NPC 체크

    [Header("Managers")]
    public int textCount = 0; // 대화 카운트
    public QuestManager01 questManager01; // 퀘스트 매니저 참조
    public GameManager gameManager; // 게임 매니저 참조

    [Header("Player Buttons")]
    public GameObject[] playerCharacterButtonList = new GameObject[4];

    [Header("Dialogue Audio")]
    public AudioClip[] dialogueClips; // 각 대사에 해당하는 오디오 클립 배열
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
                npcName.text = "메르헨";
                textObject.text = "일어나세요 일어나세요!";
                PlayDialogue(0); // 첫 번째 대사 오디오 재생
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
                    npcName.text = "벨즈";
                    textObject.text = "헉 세상이 외 이레요?";
                    PlayDialogue(1);
                    textCount++;
                    break;
                case 2:
                    npcName.text = "메르헨";
                    textObject.text = "대 재앙이 이미 시작되었요 모든것이 사라지고 모든것이 파괴 되었요.";
                    PlayDialogue(2);
                    textCount++;
                    break;
                case 3:
                    npcName.text = "메르헨";
                    textObject.text = "지금 여기 남은 생존자는 당신과 저 뿐이예요.";
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
