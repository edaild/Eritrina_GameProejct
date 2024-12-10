using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("�κ��丮")]
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
            uiData.KeyCountText.text = $"���� ���� ���� ȹ�� ���� ������{keyCount}/ 4 �Դϴ�.";
            keyCount++;
        } 
    }
}
