using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerTrigger : MainQuest01
//{
  

//    private void OnTriggerEnter(Collider other)
//    {
//        // Player�� �浹 �� ��ȭ ����
//        if (other.CompareTag("smile lady") || other.CompareTag("reception"))
//        {
//            Debug.Log("��ȭ�� �Ϸ��� F Ű�� ��������");
//            functionUI.SetActive(true);                             // F Ű �ȳ� UI Ȱ��ȭ
//            functiontext.text = "��ȭ   F";                         // �ȳ� �ؽ�Ʈ ����
//            NpcCheck = true;                                        // NPC���� ��ȭ �������� ����           
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        // Player�� NPC�� ������ ��� ��
//        if (other.CompareTag("smile lady") || other.CompareTag("reception"))
//        {
//            NpcCheck = false;                                   // ��ȭ �Ұ������� ����
//            textUI.SetActive(false);                            // ��ȭ UI ��Ȱ��ȭ
//            PlayerHpbar.SetActive(true);                         // Player HP �� Ȱ��ȭ
//            functionUI.SetActive(false);                        // F Ű �ȳ� UI ��Ȱ��ȭ
//        }
//    }
//}
