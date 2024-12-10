using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("ÀÎº¥Åä¸®")]
    public GameObject Key;
    public int keyCount = 0;

    public UIData uiData;
    private void Start()
    {
        uiData = FindAnyObjectByType<UIData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            uiData.KeyCountText.text = $"ÇöÀç ³²Àº ¿­¼â È¹µæ ¿­¼â °¹¼ö´Â{keyCount}/ 4 ÀÔ´Ï´Ù.";
            keyCount++;
        } 
    }
}
