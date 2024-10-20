using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [Header("Function UI")]
    public GameObject functionUI;
    public Text functionText;

    private bool LobbyIn = false;
    private bool LobbyInOut = false;

    private void Update()
    {
        // 플레이어가 트리거 안에 있을 때 F 키 입력 체크
        if (LobbyIn && Input.GetKeyDown(KeyCode.F))
        {
            LoadScene("LobbyScene");
        }
        if (LobbyInOut && Input.GetKeyDown(KeyCode.F))
        {
            LoadScene("HotelScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.CompareTag("Lobby In"))
            {
                LobbyIn = true;
                functionUI.SetActive(true);
                functionText.text = "로비로 이동  F";
            }

            if (transform.CompareTag("Lobby Out"))
            {
                LobbyInOut = true;
                functionUI.SetActive(true);
                functionText.text = "호텔 외부로 이동  F";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LobbyIn = false;
            LobbyInOut = false;
            functionUI.SetActive(false);
        }
    }

    // 씬 로드 메서드
    public void LoadScene(string sceneName)
    {
        Debug.Log($"{sceneName} 씬 로드 중");
        SceneManager.LoadScene(sceneName);
    }
}

