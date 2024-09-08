using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class GameManiser : MonoBehaviour
{
    public GameObject[] lodingIcon = new GameObject[5]; // 로딩 아이콘
    public float lodingTime = 12f;

    private void Update()
    {
        lodingTime -= Time.deltaTime;

        if (lodingTime <= 10) lodingIcon[0].SetActive(true);
        
        if (lodingTime <= 8) lodingIcon[1].SetActive(true);

        if (lodingTime <= 6) lodingIcon[2].SetActive(true);
   
        if (lodingTime <= 4) lodingIcon[3].SetActive(true);
    
        if (lodingTime <= 0) SceneManager.LoadScene("HotelsScene");
     
    }
}

