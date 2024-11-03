using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainQuestNpc01 : PrologScript
{

    private void OnTriggerEnter(Collider other)
    {
        // Player�� �浹 �� ��ȭ ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("��ȭ�� �Ϸ��� F Ű�� ��������");
            functionUI.SetActive(true);                             // F Ű �ȳ� UI Ȱ��ȭ
            functionText.text = "��ȭ   F";                         // �ȳ� �ؽ�Ʈ ����
            npcCheck = true;                                        // NPC���� ��ȭ �������� ����           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Player�� NPC�� ������ ��� ��
        if (other.CompareTag("Player"))
        {
           npcCheck = false;                                   // ��ȭ �Ұ������� ����
            textUI.SetActive(false);                            // ��ȭ UI ��Ȱ��ȭ
            playerHpBar.SetActive(true);                         // Player HP �� Ȱ��ȭ
            functionUI.SetActive(false);                        // F Ű �ȳ� UI ��Ȱ��ȭ
            textCount = 0;                                     // ��ȭ ī��Ʈ �ʱ�ȭ
        }
    }
}
