using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // 씬 관리 관련 네임스페이스 추가

public class UIManager : MonoBehaviour
{
    public GameObject MenuButton;       // 메뉴 버튼
    public GameObject MainMenu;         // 메인 메뉴 UI
    private bool MainMenuCheck;         // 메뉴 상태 체크

    [Header("메인 메뉴")]
    public GameObject GamePlayButton;   // 게임 플레이 버튼
    public GameObject RePlay;           // 리플레이 버튼
    public GameObject GameExit;         // 게임 종료 버튼

    // 메뉴 버튼 클릭 시 호출되는 함수
    public void onButtonclickMenuButton()
    {
        if (!MainMenuCheck)
        {
            // 메뉴가 활성화되면 게임을 일시 정지
            Time.timeScale = 0f;  // 게임 일시 정지
            MainMenu.SetActive(true);  // 메뉴 UI 활성화
            MainMenuCheck = true;  // 메뉴 활성화 상태로 설정
        }
        else
        {
            // 메뉴가 비활성화되면 게임이 재개
            Time.timeScale = 1f;  // 게임 재개
            MainMenu.SetActive(false);  // 메뉴 UI 비활성화
            MainMenuCheck = false;  // 메뉴 비활성화 상태로 설정
        }
    }

    // 계속하기 버튼 클릭 시 호출되는 함수
    public void OnContinueButtonClick()
    {
        // 게임을 재개하고, 메뉴를 닫고 게임을 계속
        Time.timeScale = 1f;  // 게임 재개
        MainMenu.SetActive(false);  // 메뉴 UI 비활성화
        MainMenuCheck = false;  // 메뉴 비활성화 상태로 설정
    }

    // 리플레이 버튼 클릭 시 호출되는 함수
    public void OnReplayButtonClick()
    {
        // 게임을 재시작하고, 메뉴를 닫고 게임을 다시 시작
        Time.timeScale = 1f;  // 게임 재개
        MainMenu.SetActive(false);  // 메뉴 UI 비활성화
        MainMenuCheck = false;  // 메뉴 비활성화 상태로 설정

        // 현재 씬을 다시 로드하여 리플레이 처리
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 현재 씬을 다시 로드
    }

    // 게임 종료 버튼 클릭 시 호출되는 함수
    public void OnExitButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
