using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerLever : MonoBehaviour
{
    [Header("Player Level settings")]
    [Tooltip("current player level")]
    public float playerLevel = 1f;

    [Tooltip("Text component to display the player level")]
    public Text levelText;

    private const float MaxLevel = 60f;

    private void Update()
    {
        HandIeInput();
    }

    private void HandIeInput()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            IncreaseLevel();
        }
    }

    private void IncreaseLevel()
    {
        if (playerLevel < MaxLevel)
        {
            playerLevel += 1f;
            if (playerLevel >= MaxLevel)
            {
                playerLevel = MaxLevel;
                Debug.Log("축하합니다. 최대 레벨을 달성하셨습니다.");
            }
        }
        else
        {
            Debug.Log("더 이상은 점수를 올릴 수 없습니다.");
        }
    }

    private void updateleveldisplay()
    {
        levelText.text = $"Level {playerLevel}";
    }
}
