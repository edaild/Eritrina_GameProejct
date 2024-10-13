using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [Tooltip("캐릭터 배열")] public GameObject[] playerCharacter = new GameObject[2]; // 캐릭터 배열 추가
    [Tooltip("버튼 배열")] public Button[] characterButtons; // UI 버튼 배열 추가

    // 활성화된 버튼 색상 (16진수 색상 코드 #3E3593)
    private Color activeColor = new Color32(62, 53, 147, 178); // RGB(62, 53, 147) 및 Alpha(255)
    private Color inactiveColor = new Color32(0, 0, 0, 178); // RGB(0, 0, 0) 및 Alpha(255)

    // 캐릭터 상태 초기화
    private void Start()
    {
        // 만약 playerCharacter 에 배열이 0보다 클 경우
        if (playerCharacter.Length > 0)
        {
            // i 가 playerCharacter 배열 보다 작다면
            for (int i = 0; i < playerCharacter.Length; i++)
            {
                // 첫 번째 케릭터만 활성화
                playerCharacter[i].SetActive(i == 0);
                // 버튼 색상도 초기화
                characterButtons[i].image.color = i == 0 ? activeColor : inactiveColor;
            }
        }
    }

    public void OnButtonClickCharacter(int characterIndex)
    {
        // characterIndex가 배열의 범위 내에 있는지 확인
        // 만약 character Index 가 0 보다 크거나 같고  그리고 playerCharacter.Length 보다 작으면
        if (characterIndex >= 0 && characterIndex < playerCharacter.Length)
        {
            // 선택된 캐릭터를 활성화하고 나머지는 비활성
            // i = 0을로 초기화 하고 i 가 playerCharacter.Length 보다 작으며 i 를 증가 시켜라
            for (int i = 0; i < playerCharacter.Length; i++)
            {
                playerCharacter[i].SetActive(i == characterIndex);
                // 버튼 색상도 업데이트
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
