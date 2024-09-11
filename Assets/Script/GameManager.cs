using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Loading Icons")]
    public GameObject[] loadingIcons; // 로딩 아이콘 배열
    public float loadingTime = 5f; // 로딩 타이머
    private bool sceneLoaded = false; // 씬이 로드되었는지 여부를 추적
   

    private void Start()
    {
        InitializeLoadingIcons();
    }

    private void Update()
    {
        if (sceneLoaded)
            return; 

        UpdateLoadingTime();
        CheckAndActivateIcons(); // 확인및 활성화 아이콘
        TryLoadScene();
    }

    
    private void InitializeLoadingIcons() // 로딩 아이콘 초기화
    {
        foreach (GameObject icon in loadingIcons)
        {
            icon.SetActive(false); 
        }
    }


    private void UpdateLoadingTime()
    {
        loadingTime -= Time.deltaTime;
    }

  
    private void CheckAndActivateIcons()
    {
        if (loadingTime <= 4 && !loadingIcons[0].activeSelf)
            loadingIcons[0].SetActive(true);


        if (loadingTime <= 3 && !loadingIcons[1].activeSelf)
            loadingIcons[1].SetActive(true);

        if (loadingTime <= 2 && !loadingIcons[2].activeSelf)
            loadingIcons[2].SetActive(true);

        if (loadingTime <= 1 && !loadingIcons[3].activeSelf)
            loadingIcons[3].SetActive(true);
    }

   
    private void TryLoadScene()
    {
        if (loadingTime <= 0 && !sceneLoaded)
        {
            SceneManager.LoadScene("HotelsScene");
            sceneLoaded = true; 
        }
    }
}

