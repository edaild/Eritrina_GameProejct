using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // 게임 시작 버튼 클릭 시
    public void OnButtonClick_GameStart()
    {
        SceneManager.LoadScene("GameScene");  // 게임 씬으로 전환
    }

    // 게임 종료 버튼 클릭 시
    public void OnButtonExit()
    {
        // 게임 종료
        Debug.Log("게임을 종료합니다.");
        Application.Quit();  // 빌드된 게임에서는 게임 종료

#if UNITY_EDITOR
        // Unity 에디터에서 게임 종료
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
