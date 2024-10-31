using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerTrigger : MainQuest01
//{
  

//    private void OnTriggerEnter(Collider other)
//    {
//        // Player와 충돌 시 대화 가능
//        if (other.CompareTag("smile lady") || other.CompareTag("reception"))
//        {
//            Debug.Log("대화를 하려면 F 키를 누르세요");
//            functionUI.SetActive(true);                             // F 키 안내 UI 활성화
//            functiontext.text = "대화   F";                         // 안내 텍스트 설정
//            NpcCheck = true;                                        // NPC와의 대화 가능으로 설정           
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        // Player가 NPC의 범위를 벗어날 때
//        if (other.CompareTag("smile lady") || other.CompareTag("reception"))
//        {
//            NpcCheck = false;                                   // 대화 불가능으로 설정
//            textUI.SetActive(false);                            // 대화 UI 비활성화
//            PlayerHpbar.SetActive(true);                         // Player HP 바 활성화
//            functionUI.SetActive(false);                        // F 키 안내 UI 비활성화
//        }
//    }
//}
