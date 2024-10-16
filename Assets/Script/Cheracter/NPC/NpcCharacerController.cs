using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcCharacterController : MonoBehaviour
{
    [Header("NPC system")]
    public GameObject[] NpcCharacter; // NPC ĳ���� �迭

   // public GameObject FKeyUI; // F Ű �ȳ� UI
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
                    textUI.SetActive(true); // ��ȭ UI Ȱ��ȭ
                    hpbar. SetActive(false); // HP �� ��Ȱ��ȭ
                    menuButton.SetActive(false); // �޴� ��ư ��Ȱ��ȭ
                    npcName.text = "����"; // NPC �̸� ����
                    textObject.text = "�ȳ��ϼ���."; // ù ��° ��ȭ ����
                    text_Count = 1; // ��ȭ ī��Ʈ ����
                }
            }

            // ���콺 Ŭ������ ��ȭ ����
            if (text_Count == 1 && Input.GetMouseButton(0))
            {
                textObject.text = "����Ʈ���� ȣ�ڿ� ���Ű� ȯ���մϴ�."; // �� ��° ��ȭ ����
                text_Count = 2; // ��ȭ ī��Ʈ ����
            }
            else if (text_Count == 2 && Input.GetMouseButton(0))
            {
                textObject.text = "��ſ� �޽� �Ǽ���."; // �� ��° ��ȭ ����
                text_Count = 3; // ��ȭ ī��Ʈ ����
            }
            else if (text_Count == 3 && Input.GetMouseButton(0))
            {
                textUI.SetActive(false); // ��� ��ȭ�� ������ UI ��Ȱ��ȭ
                text_Count = 0; // ��ȭ ī��Ʈ �ʱ�ȭ
                NpcCheck = false; // ��ȭ �Ұ������� ����
            }
        }
        else
        {
           // FKeyUI.SetActive(false); // ��ȭ �Ұ��� �� F Ű �ȳ� UI ��Ȱ��ȭ
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player�� �浹 �� ��ȭ ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("��ȭ�� �Ϸ��� F Ű�� ��������");
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
            text_Count = 0; // ��ȭ ī��Ʈ �ʱ�ȭ
        }
    }
}
