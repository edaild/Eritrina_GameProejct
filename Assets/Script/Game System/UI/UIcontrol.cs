//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class uIcontrol : MonoBehaviour
//{
//    [Header("UI 시스탬")]
//    [Tooltip("테블릿 메뉴")]public GameObject MainMenu; // 메인메뉴
//    [Tooltip("지도")]public GameObject map; // 지도 
//    [Tooltip("캐릭터 UI")]public GameObject characterButton01; // 캐릭터 UI 01
//    [Tooltip("캐릭터 UI")]public GameObject characterButton02; // 캐릭터 UI 02
//    [Tooltip("캐릭터 UI")]public GameObject characterButton03; // 캐릭터 UI 03
//    [Tooltip("캐릭터 UI")]public GameObject characterButton04; // 캐릭터 UI 04

    
//    public GameObject functionUI; // F 키 안내 UI
//    public MainQuest01 MainQuest01;
//    public QuestManager questManager;


//    public bool Mainmenu_On; // 메인메뉴 확인
//    public bool Mapmenu_On; // 지도 확인


//    public void Start()
//    {
//        MainQuest01 = FindObjectOfType<MainQuest01>();
//        questManager = FindObjectOfType<QuestManager>();
//    }

//    // Main Menu
//    public void Onbuttonclick_MainMenu()
//    {
//       if (Mainmenu_On  == false)
//        {
//            MainMenu.gameObject.SetActive(true); 
//            Mainmenu_On = true;
//            questManager.questUI.gameObject.SetActive(false);
//            functionUI.gameObject.SetActive(false);
//        }
//        else
//        {
//            MainMenu.gameObject.SetActive(false); 
//            Mainmenu_On = false;
//            questManager.questUI.gameObject.SetActive(true);
//            functionUI.gameObject.SetActive(true);

//        }      
//    }

//   // Map

//    public void OnButtonclick_MapMenu()
//    {
//        if (Mapmenu_On == false)
//        {
//            map.gameObject.SetActive(true); 
//            Mapmenu_On = true;
//        }
//        else
//        {
//            map.gameObject.SetActive(false); 
//            Mapmenu_On = false;
          
//        }
//    }

//    void Mapkey()
//    {
//        if (Input. GetKeyDown(KeyCode.M))
//        {
//            if (Mapmenu_On == false)
//            {
//                map.gameObject.SetActive(true); 
//                Mapmenu_On = true;
//            }
//            else
//            {
//                map.gameObject.SetActive(false); 
//                Mapmenu_On = false;
//            }
//        }
//    }

//    public void offMainmenu()
//    {
//        if (Mainmenu_On == true)
//        {
//            characterButton01.gameObject.SetActive(false);
//            characterButton02.gameObject.SetActive(false);
//            characterButton03.gameObject.SetActive(false);
//            characterButton04.gameObject.SetActive(false);
//        }
//        else
//        {
//            characterButton01.gameObject.SetActive(true);
//            characterButton02.gameObject.SetActive(true);
//            characterButton03.gameObject.SetActive(true);
//            characterButton04.gameObject.SetActive(true);
//        }
//    }

//    // keyboard

//    private void Update()
//    {
//        Mapkey();
//        offMainmenu();
//    }
//}

    
