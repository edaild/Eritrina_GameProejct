using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class uIcontrol : MonoBehaviour
{
    [Header("UI �ý���")]
    [Tooltip("�׺� �޴�")]public GameObject MainMenu; // ���θ޴�
    [Tooltip("����")]public GameObject map; // ���� 
    [Tooltip("����Ʈ")] public GameObject Quest; // ����Ʈ
    [Tooltip("ĳ���� UI")]public GameObject characterButton01; // ĳ���� UI 01
    [Tooltip("ĳ���� UI")]public GameObject characterButton02; // ĳ���� UI 02
    [Tooltip("ĳ���� UI")]public GameObject characterButton03; // ĳ���� UI 03
    [Tooltip("ĳ���� UI")]public GameObject characterButton04; // ĳ���� UI 04

    public GameObject functionUI; // F Ű �ȳ� UI
  //  public MainQuest01 MainQuest01;


    public bool Mainmenu_On; // ���θ޴� Ȯ��
    public bool Mapmenu_On; // ���� Ȯ��


    public void Start()
    {
       // MainQuest01 = FindObjectOfType<MainQuest01>();
    }

    // Main Menu
    public void Onbuttonclick_MainMenu()
    {
       if (Mainmenu_On  == false)
        {
            MainMenu.gameObject.SetActive(true); 
            Mainmenu_On = true;
            Quest.gameObject. SetActive(false);
            functionUI.gameObject.SetActive(false);
        }
        else
        {
            MainMenu.gameObject.SetActive(false); 
            Mainmenu_On = false;
            Quest.gameObject.SetActive(true);
            functionUI.gameObject.SetActive(true);

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
            characterButton03.gameObject.SetActive(false);
            characterButton04.gameObject.SetActive(false);
        }
        else
        {
            characterButton01.gameObject.SetActive(true);
            characterButton02.gameObject.SetActive(true);
            characterButton03.gameObject.SetActive(true);
            characterButton04.gameObject.SetActive(true);
        }
    }

    // keyboard

    private void Update()
    {
        Mapkey();
        offMainmenu();
    }
}

    
