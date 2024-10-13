using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [Tooltip("ĳ���� �迭")] public GameObject[] playerCharacter = new GameObject[2]; // ĳ���� �迭 �߰�
    [Tooltip("��ư �迭")] public Button[] characterButtons; // UI ��ư �迭 �߰�

    // Ȱ��ȭ�� ��ư ���� (16���� ���� �ڵ� #3E3593)
    private Color activeColor = new Color32(62, 53, 147, 178); // RGB(62, 53, 147) �� Alpha(255)
    private Color inactiveColor = new Color32(0, 0, 0, 178); // RGB(0, 0, 0) �� Alpha(255)

    // ĳ���� ���� �ʱ�ȭ
    private void Start()
    {
        // ���� playerCharacter �� �迭�� 0���� Ŭ ���
        if (playerCharacter.Length > 0)
        {
            // i �� playerCharacter �迭 ���� �۴ٸ�
            for (int i = 0; i < playerCharacter.Length; i++)
            {
                // ù ��° �ɸ��͸� Ȱ��ȭ
                playerCharacter[i].SetActive(i == 0);
                // ��ư ���� �ʱ�ȭ
                characterButtons[i].image.color = i == 0 ? activeColor : inactiveColor;
            }
        }
    }

    public void OnButtonClickCharacter(int characterIndex)
    {
        // characterIndex�� �迭�� ���� ���� �ִ��� Ȯ��
        // ���� character Index �� 0 ���� ũ�ų� ����  �׸��� playerCharacter.Length ���� ������
        if (characterIndex >= 0 && characterIndex < playerCharacter.Length)
        {
            // ���õ� ĳ���͸� Ȱ��ȭ�ϰ� �������� ��Ȱ��
            // i = 0���� �ʱ�ȭ �ϰ� i �� playerCharacter.Length ���� ������ i �� ���� ���Ѷ�
            for (int i = 0; i < playerCharacter.Length; i++)
            {
                playerCharacter[i].SetActive(i == characterIndex);
                // ��ư ���� ������Ʈ
                characterButtons[i].image.color = i == characterIndex ? activeColor : inactiveColor;
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnButtonClickCharacter(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnButtonClickCharacter(1);
        }
    }
}
