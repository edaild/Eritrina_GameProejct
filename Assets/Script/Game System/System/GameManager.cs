using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int mainQuestCount = 0; // ����Ʈ ����
    public int playerExperience = 0; // �÷��̾� ����ġ
    public int playerLevel = 1; // �÷��̾� ����

    public void AddExperience(int amount)
    {
        playerExperience += amount;
        if (playerExperience >= 100) // 100 ����ġ���� ������
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        playerLevel++;
        playerExperience = 0; // ����ġ �ʱ�ȭ
        Debug.Log($"������! ���� ����: {playerLevel}");
    }
}
