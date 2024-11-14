using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [Header("���������� �ý���")]
    public GameObject functionUI;       // function UI
    public Text functionText;           // function Text

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            functionUI.SetActive(true);
            functionText.text = "���������� �̿�  F";
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


