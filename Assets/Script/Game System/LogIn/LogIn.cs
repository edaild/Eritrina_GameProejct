using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    [Header("�α���")]
    public InputField user_Id;
    public InputField User_password;

    // �ӽ� ID�� �ӽ� password ����
    public string test_Id = "user1234";
    public string test_pw = "user1234";

    public GameObject login; // �α��� ȭ��

    public bool Iogin_Check; // �α��� üũ

    public void OnButtonClick_GameStart()
    {
        if (!Iogin_Check)
        {
            login.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("preparationScene");
        }
    }

    public void OnButtonClick_LoginButton()
    {
        // ���� DB ���� �ڵ� �ۼ�
        if (user_Id.text == test_Id && User_password.text == test_pw) 
        {
            login.SetActive(false);
            Iogin_Check = true; // �α��� ����
        }
        else
        {
            Debug.Log("�α��� ����: �߸��� ����� �̸� �Ǵ� ��й�ȣ.");
        }
    }
}
