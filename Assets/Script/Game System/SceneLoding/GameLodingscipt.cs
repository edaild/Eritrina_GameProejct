using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLodingscipt : MonoBehaviour
{
    [Header("Loading Icons")]
    public GameObject[] loadingIcons; // �ε� ������ �迭
    public float loadingTime = 5f; // �ε� Ÿ�̸�
    private bool sceneLoaded = false; // ���� �ε�Ǿ����� ���θ� ����
   

    private void Start()
    {
        InitializeLoadingIcons();
    }

    private void Update()
    {
        if (sceneLoaded)
            return; 

        UpdateLoadingTime();
        CheckAndActivateIcons(); // Ȯ�ι� Ȱ��ȭ ������
        TryLoadScene();
    }

    
    private void InitializeLoadingIcons() // �ε� ������ �ʱ�ȭ
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
            SceneManager.LoadScene("HotelScene");
            sceneLoaded = true; 
        }
    }
}

