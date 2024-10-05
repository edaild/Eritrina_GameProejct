using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class uIcontrol : MonoBehaviour
{
    public GameObject MainMenu; // 메인메뉴
    public GameObject letterMenu; // 우편
    public GameObject map; // 지도
    public GameObject characterButton01; // 캐릭터 UI 01
    public GameObject characterButton02; // 캐릭터 UI 02
    public GameObject playerHpbar; // player 채력바

    public bool Mainmenu_On; // 메인메뉴 확인
    public bool Mapmenu_On; // 지도 확인

    // Main Menu
    public void Onbuttonclick_MainMenu()
    {
       if (Mainmenu_On  == false)
        {
            MainMenu.gameObject.SetActive(true); 
            Mainmenu_On = true;
        }
        else
        {
            MainMenu.gameObject.SetActive(false); 
            Mainmenu_On = false;
        }      
    }

   // Map

    public void OnButtonclick_MapMenu()
    {
        if (Mapmenu_On == false)
        {
            map.gameObject.SetActive(true); 
            Mapmenu_On = true;
        }
        else
        {
            map.gameObject.SetActive(false); 
            Mapmenu_On = false;
        }
    }

    void Mapkey()
    {
        if (Input. GetKeyDown(KeyCode.M))
        {
            if (Mapmenu_On == false)
            {
                map.gameObject.SetActive(true); 
                Mapmenu_On = true;
            }
            else
            {
                map.gameObject.SetActive(false); 
                Mapmenu_On = false;
            }
        }
    }

    public void offMainmenu()
    {
        if (Mainmenu_On == true)
        {
            characterButton01.gameObject.SetActive(false);
            characterButton02.gameObject.SetActive(false);
            playerHpbar.gameObject.SetActive(false);
        }
        else
        {
            characterButton01.gameObject.SetActive(true);
            characterButton02.gameObject.SetActive(true);
            playerHpbar.gameObject.SetActive(true);
        }
    }

    // keyboard

    private void Update()
    {
        Mapkey();
        offMainmenu();
    }
}

    
