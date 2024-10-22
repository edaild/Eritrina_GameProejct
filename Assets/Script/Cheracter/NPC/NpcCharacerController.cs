using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcCharacterController : MonoBehaviour
{
    [Header("NPC system")]
    public GameObject[] NpcCharacter; // NPC ĳ���� �迭

    public GameObject functionUI; // F Ű �ȳ� UI
    public Text functiontext;
    public float NpcSpeed; // NPC �ӵ� (���� ������ ����)

    public GameObject textUI; // ��ȭ UI
    public Text npcName; // NPC �̸��� ǥ���� UI �ؽ�Ʈ
    public Text textObject; // ��ȭ ������ ǥ���� UI �ؽ�Ʈ
    public GameObject npcImags; // NPC �̹��� (���� ������ ����)
    public GameObject hpbar; // HP �� (���� ��Ȱ��ȭ)
    public GameObject menuButton; // �޴� ��ư (���� ��Ȱ��ȭ)

    public int text_Count = 0; // ��ȭ ī��Ʈ

    public bool NpcCheck; // NPC���� ��ȭ ���� ����

    private void Start()
    {
        NpcCheck = false; // �ʱ⿡�� ��ȭ �Ұ��� ����
        textUI.SetActive(false); // ��ȭ UI ��Ȱ��ȭ
    }

    private void Update()
    {
        if (NpcCheck)
        {
            // FKeyUI.SetActive(true); // F Ű �ȳ� UI Ȱ��ȭ
            if (Input.GetKeyDown(KeyCode.F))
            {
                // ���� ������Ʈ�� "NPC" �±��� ��� ��ȭ ����
                if (transform.CompareTag("NPC") && text_Count == 0)
                {
                    functionUI.SetActive(false);
                    textUI.SetActive(true); // ��ȭ UI Ȱ��ȭ
                    hpbar.SetActive(false); // HP �� ��Ȱ��ȭ
                    menuButton.SetActive(false); // �޴� ��ư ��Ȱ��ȭ
                    functionUI.SetActive(false);
                    npcName.text = "����"; // NPC �̸� ����
                    textObject.text = "�ȳ��ϼ���."; // ù ��° ��ȭ ����
                    text_Count = 1; // ��ȭ ī��Ʈ ����

                }
            }
            // CompareTag �� NPC �̰� ���콺 ���� ��ư�� ������ ���
            if ((transform.CompareTag("NPC") && Input.GetMouseButtonDown(0)))
            {
                // ���콺 Ŭ������ ��ȭ ����
                if (text_Count == 1)
                {
                    textObject.text = "����Ʈ���� ȣ�ڿ� ���Ű� ȯ���մϴ�."; // �� ��° ��ȭ ����
                    text_Count = 2; // ��ȭ ī��Ʈ ����
                }
                else if (text_Count == 2)
                {
                    textObject.text = "��ſ� �޽� �Ǽ���."; // �� ��° ��ȭ ����
                    text_Count = 3; // ��ȭ ī��Ʈ ����
                }
                else if (text_Count == 3)
                {
                    textUI.SetActive(false); // ��� ��ȭ�� ������ UI ��Ȱ��ȭ
                    text_Count = 0; // ��ȭ ī��Ʈ �ʱ�ȭ
                    NpcCheck = false; // ��ȭ �Ұ������� ����
                    hpbar.SetActive(true); // player HP �� Ȱ��ȭ
                    functionUI.SetActive(true);
                    menuButton.SetActive(true);
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
            functionUI.SetActive(true);
            functiontext.text = "��ȭ   F";
            NpcCheck = true; // NPC���� ��ȭ �������� ����
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player�� NPC�� ������ ��� ��
        if (other.CompareTag("Player"))
        {
            NpcCheck = false; // ��ȭ �Ұ������� ����
            textUI.SetActive(false); // ��ȭ UI ��Ȱ��ȭ
            hpbar.SetActive(true); // Player Hp�ٸ� Ȱ��ȭ
            functionUI.SetActive(false);
            text_Count = 0; // ��ȭ ī��Ʈ �ʱ�ȭ
        }
    }
}
