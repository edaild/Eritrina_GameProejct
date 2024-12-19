using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // ���� ���� ��ư Ŭ�� ��
    public void OnButtonClick_GameStart()
    {
        SceneManager.LoadScene("GameScene");  // ���� ������ ��ȯ
    }

    // ���� ���� ��ư Ŭ�� ��
    public void OnButtonExit()
    {
        // ���� ����
        Debug.Log("������ �����մϴ�.");
        Application.Quit();  // ����� ���ӿ����� ���� ����

#if UNITY_EDITOR
        // Unity �����Ϳ��� ���� ����
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
