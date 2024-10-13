using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class LogIn : MonoBehaviour
{
    [SerializeField]

    public GameObject login; // �α��� ȭ��
    public bool Iogin_Check; // �α��� üũ
    public bool playerId_input;
    public bool playerpw_input;

    public void OnButtonClick_GameStart()
    {
        if (!Iogin_Check)
        {
            login.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("preparationScene");
        }   
    }

    public void OnButtonClick_LoginButton()
    {
        // ���� DB�� ���۵Ǵ� �ڵ�� ������ DB �� ����� ID�� PassWord�� ��ġ���� Ȯ�� �� �� ���� ���� �ڵ� �ۼ�
        login.gameObject.SetActive(false); Iogin_Check = true;
    }
}
