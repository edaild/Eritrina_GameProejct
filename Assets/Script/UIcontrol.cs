using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class uIcontrol : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject letterMenu;
    public GameObject Map;
    public bool Mapmenu_true;

    // Main Menu
    public void Onbuttonclick_MainMenu()
    {
        MainMenu.SetActive(true);
       
    }

    public void Onbuttonclick_MenuMenu_close()
    {
        MainMenu.SetActive(false);
    }

    // Letter Menu
    public void  Onbuttonclick_letterMenu()
    {
         letterMenu.SetActive(true); 
    }

    public void Onbuttonclick_letterMneu_close()
    {
        letterMenu.SetActive(false); 
    }

   // Map

    public void OnButtonclick_MapMenu()
    {
        if (Mapmenu_true == false)
        {
            Map.gameObject.SetActive(true); Mapmenu_true = true;
        }
        else
        {
            Map.gameObject.SetActive(false); Mapmenu_true = false;
        }
    }

    void Mapkey()
    {
        if (Input. GetKeyDown(KeyCode.M))
        {
            if (Mapmenu_true == false)
            {
                Map.gameObject.SetActive(true); Mapmenu_true = true;
            }
            else
            {
                Map.gameObject.SetActive(false); Mapmenu_true = false;
            }
        }
    }

    // 키보드 동작

    private void Update()
    {
        Mapkey();
    }
}

    
