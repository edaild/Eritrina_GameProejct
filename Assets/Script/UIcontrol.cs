using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class uIcontrol : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject letterMenu;
    public GameObject map;
    public GameObject characterButton01;
    public GameObject characterButton02;
    public GameObject playerHpbar;

    public bool Mainmenu_On;
    public bool Mapmenu_On;

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

    
