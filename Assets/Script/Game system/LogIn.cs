using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class LogIn : MonoBehaviour
{
    [SerializeField]

    public GameObject login; // 로그인 화면
    public bool Iogin_Check; // 로그인 체크
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
        // 추후 DB로 전송되는 코드로 수정및 DB 에 저장된 ID와 PassWord가 일치한지 확인 후 참 거짓 구분 코드 작성
        login.gameObject.SetActive(false); Iogin_Check = true;
    }
}
