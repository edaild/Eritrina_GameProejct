using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // �� ���� ���� ���ӽ����̽� �߰�

public class UIManager : MonoBehaviour
{
    public GameObject MenuButton;       // �޴� ��ư
    public GameObject MainMenu;         // ���� �޴� UI
    private bool MainMenuCheck;         // �޴� ���� üũ

    [Header("���� �޴�")]
    public GameObject GamePlayButton;   // ���� �÷��� ��ư
    public GameObject RePlay;           // ���÷��� ��ư
    public GameObject GameExit;         // ���� ���� ��ư

    // �޴� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void onButtonclickMenuButton()
    {
        if (!MainMenuCheck)
        {
            // �޴��� Ȱ��ȭ�Ǹ� ������ �Ͻ� ����
            Time.timeScale = 0f;  // ���� �Ͻ� ����
            MainMenu.SetActive(true);  // �޴� UI Ȱ��ȭ
            MainMenuCheck = true;  // �޴� Ȱ��ȭ ���·� ����
        }
        else
        {
            // �޴��� ��Ȱ��ȭ�Ǹ� ������ �簳
            Time.timeScale = 1f;  // ���� �簳
            MainMenu.SetActive(false);  // �޴� UI ��Ȱ��ȭ
            MainMenuCheck = false;  // �޴� ��Ȱ��ȭ ���·� ����
        }
    }

    // ����ϱ� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnContinueButtonClick()
    {
        // ������ �簳�ϰ�, �޴��� �ݰ� ������ ���
        Time.timeScale = 1f;  // ���� �簳
        MainMenu.SetActive(false);  // �޴� UI ��Ȱ��ȭ
        MainMenuCheck = false;  // �޴� ��Ȱ��ȭ ���·� ����
    }

    // ���÷��� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnReplayButtonClick()
    {
        // ������ ������ϰ�, �޴��� �ݰ� ������ �ٽ� ����
        Time.timeScale = 1f;  // ���� �簳
        MainMenu.SetActive(false);  // �޴� UI ��Ȱ��ȭ
        MainMenuCheck = false;  // �޴� ��Ȱ��ȭ ���·� ����

        // ���� ���� �ٽ� �ε��Ͽ� ���÷��� ó��
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // ���� ���� �ٽ� �ε�
    }

    // ���� ���� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnExitButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
