using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    [Header("로그인")]
    public InputField user_Id;
    public InputField User_password;

    // 임시 ID와 임시 password 지정
    public string test_Id = "user1234";
    public string test_pw = "user1234";

    public GameObject login; // 로그인 화면

    public bool Iogin_Check; // 로그인 체크

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
        // 추후 DB 연결 코드 작성
        if (user_Id.text == test_Id && User_password.text == test_pw) 
        {
            login.SetActive(false);
            Iogin_Check = true; // 로그인 성공
        }
        else
        {
            Debug.Log("로그인 실패: 잘못된 사용자 이름 또는 비밀번호.");
        }
    }
}
