using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int mainQuestCount = 0; // 퀘스트 상태
    public int playerExperience = 0; // 플레이어 경험치
    public int playerLevel = 1; // 플레이어 레벨

    public void AddExperience(int amount)
    {
        playerExperience += amount;
        if (playerExperience >= 100) // 100 경험치마다 레벨업
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        playerLevel++;
        playerExperience = 0; // 경험치 초기화
        Debug.Log($"레벨업! 현재 레벨: {playerLevel}");
    }
}
