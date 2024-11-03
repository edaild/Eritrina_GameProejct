using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject[] LeverButton = new GameObject[5];
    public GameObject GameStartUI; // 전투 단계창

    private bool isGameStartUI;
    public void Onbuttonclick_Game()
    {  
        GameStartUI.gameObject.SetActive(true); // 전투 단계창을 틀어줘라       
    }
    public void Onbuttonclick_Game_Exit()
    {
        GameStartUI.gameObject.SetActive(false); // 전투 단계창을 꺼줘라       
    }


}

