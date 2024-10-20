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
        // �÷��̾ Ʈ���� �ȿ� ���� �� F Ű �Է� üũ
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
                functionText.text = "�κ�� �̵�  F";
            }

            if (transform.CompareTag("Lobby Out"))
            {
                LobbyInOut = true;
                functionUI.SetActive(true);
                functionText.text = "ȣ�� �ܺη� �̵�  F";
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

    // �� �ε� �޼���
    public void LoadScene(string sceneName)
    {
        Debug.Log($"{sceneName} �� �ε� ��");
        SceneManager.LoadScene(sceneName);
    }
}

