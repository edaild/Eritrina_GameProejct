using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [Header("엘레베이터 시스템")]
    public GameObject functionUI;       // function UI
    public Text functionText;           // function Text

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            functionUI.SetActive(true);
            functionText.text = "엘레베이터 이용  F";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            functionUI.SetActive(false);
        }
    }
 
}


