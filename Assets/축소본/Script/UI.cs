using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject[] LeverButton = new GameObject[5];
    public GameObject GameStartUI; // ���� �ܰ�â

    private bool isGameStartUI;
    public void Onbuttonclick_Game()
    {  
        GameStartUI.gameObject.SetActive(true); // ���� �ܰ�â�� Ʋ�����       
    }
    public void Onbuttonclick_Game_Exit()
    {
        GameStartUI.gameObject.SetActive(false); // ���� �ܰ�â�� �����       
    }


}

