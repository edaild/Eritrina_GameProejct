//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class NpcCharacterController : MonoBehaviour
//{
//    [Header("NPC system")]
//    public GameObject[] NpcCharacter; // NPC ĳ���� �迭

//    public GameObject functionUI; // F Ű �ȳ� UI
//    public Text functiontext; // F Ű �ȳ� �ؽ�Ʈ
//    public float NpcSpeed; // NPC �ӵ� (���� ������ ����)

//    public GameObject textUI; // ��ȭ UI
//    public Text npcName; // NPC �̸��� ǥ���� UI �ؽ�Ʈ
//    public Text textObject; // ��ȭ ������ ǥ���� UI �ؽ�Ʈ
//    public GameObject npcImages; // NPC �̹��� (���� ������ ����)
//    public GameObject hpbar; // HP �� (���� ��Ȱ��ȭ)
//    public GameObject menuButton; // �޴� ��ư (���� ��Ȱ��ȭ)

//    public bool NpcCheck; // NPC���� ��ȭ ���� ����
//    public bool NpcTextcheck; // ��ȭ ���� ���� (���� ������ ����)

//    public int text_Count = 0; // ��ȭ ī��Ʈ

//    public QuestManager questManager; // ����Ʈ �Ŵ��� ����
//    public bool NPC = false;

//    private void Start()
//    {
//        NpcCheck = false; // �ʱ⿡�� ��ȭ �Ұ��� ����
//        NpcTextcheck = false;
//        textUI.SetActive(false); // ��ȭ UI ��Ȱ��ȭ
//        questManager = FindObjectOfType<QuestManager>();
//    }

//    private void Update()
//    {
//        NpcCharacterCheck(); // NPC ��ȭ üũ
//    }

//    private void NpcCharacterCheck()
//    {
//        if (NpcCheck) // NPC�� ��ȭ ���� ������ ��
//        {
//            if (Input.GetKeyDown(KeyCode.F)) // F Ű �Է� ��
//            {
//                // ���� ������Ʈ�� "NPC" �±��� ��� ��ȭ ����
//                if (transform.CompareTag("NPC") && text_Count == 0)
//                {
//                    functionUI.SetActive(false); // F Ű �ȳ� UI ��Ȱ��ȭ
//                    textUI.SetActive(true); // ��ȭ UI Ȱ��ȭ
//                    hpbar.SetActive(false); // HP �� ��Ȱ��ȭ
//                    menuButton.SetActive(false); // �޴� ��ư ��Ȱ��ȭ
//                    npcName.text = "����"; // NPC �̸� ����
//                    textObject.text = "�ȳ��ϼ���."; // ù ��° ��ȭ ����
//                    text_Count = 1; // ��ȭ ī��Ʈ ����
//                }
//            }
//            // CompareTag�� NPC�̰� ���콺 ���� ��ư�� ������ ���
//            if (transform.CompareTag("NPC") && Input.GetMouseButtonDown(0))
//            {
//                // ���콺 Ŭ������ ��ȭ ����
//                if (text_Count == 1)
//                {
//                    textObject.text = "����Ʈ���� ȣ�ڿ� ���Ű� ȯ���մϴ�."; // �� ��° ��ȭ ����
//                    text_Count = 2; // ��ȭ ī��Ʈ ����
//                }
//                else if (text_Count == 2)
//                {
//                    textObject.text = "��ſ� �޽� �Ǽ���."; // �� ��° ��ȭ ����
//                    text_Count = 3; // ��ȭ ī��Ʈ ����
//                }
//                else if (text_Count == 3)
//                {
//                    textUI.SetActive(false); // ��� ��ȭ�� ������ UI ��Ȱ��ȭ
//                    text_Count = 0; // ��ȭ ī��Ʈ �ʱ�ȭ
//                    NpcCheck = false; // ��ȭ �Ұ������� ����
//                    hpbar.SetActive(true); // Player HP �� Ȱ��ȭ
//                    functionUI.SetActive(true); // F Ű �ȳ� UI Ȱ��ȭ
//                    menuButton.SetActive(true); // �޴� ��ư Ȱ��ȭ

//                    questManager.CompleteCurrentStep(); //  NPC�� ��ȭ �Ϸ�
//                }
//            }
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // Player�� �浹 �� ��ȭ ����
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("��ȭ�� �Ϸ��� F Ű�� ��������");
//            functionUI.SetActive(true); // F Ű �ȳ� UI Ȱ��ȭ
//            functiontext.text = "��ȭ   F"; // �ȳ� �ؽ�Ʈ ����
//            NpcCheck = true; // NPC���� ��ȭ �������� ����           
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        // Player�� NPC�� ������ ��� ��
//        if (other.CompareTag("Player"))
//        {
//            NpcCheck = false; // ��ȭ �Ұ������� ����
//            textUI.SetActive(false); // ��ȭ UI ��Ȱ��ȭ
//            hpbar.SetActive(true); // Player HP �� Ȱ��ȭ
//            functionUI.SetActive(false); // F Ű �ȳ� UI ��Ȱ��ȭ
//            text_Count = 0; // ��ȭ ī��Ʈ �ʱ�ȭ
//        }
//    }
//}


