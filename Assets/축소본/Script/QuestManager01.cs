using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager01 : MonoBehaviour
{
    private Quest currentQuest;
    public Text questText; // ���� ����Ʈ �ܰ� �ؽ�Ʈ
    public GameManager gameManager; // GameManager �ν��Ͻ�

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager ã��
        InitializeQuest(); // ����Ʈ �ʱ�ȭ
        ShowCurrentStep(); // ���� �ܰ� �����ֱ�
    }

    void InitializeQuest()
    {
        var steps = new List<string>
        {
            "���� �ִ� \n �̽��͸� �ҳ�� ��ȭ�ϱ�",
            "�Ϲݰ��� �غ���",
            "�޸����ϰ� ��ȭ�ϱ�",
            "��ų ���� �غ���",
            "�޸����ϰ� ��ȭ�ϱ�",
            "�ñر� �Ẹ��",
            "�޸����ϰ� ��ȭ�ϱ�",
        };

        currentQuest = new Quest("Ʃ�丮�� �ӹ�", steps);
        gameManager.mainQuestCount = currentQuest.currentStep; // �ʱ� ����Ʈ �ܰ� ����
    }

    public void CompleteCurrentStep()
    {
        currentQuest.CompleteStep();
        gameManager.mainQuestCount = currentQuest.currentStep; // ���� ����Ʈ �ܰ� ������Ʈ
        ShowCurrentStep();

        // ����Ʈ �Ϸ� �� ����ġ ���
        if (currentQuest.GetCurrentStepIndex() == currentQuest.GetTotalSteps())
        {
            gameManager.AddExperience(currentQuest.experience);
            Debug.Log($"����Ʈ '{currentQuest.title}' �Ϸ�! ����ġ {currentQuest.experience} ȹ��!");
        }
    }

    void ShowCurrentStep()
    {
        string currentStepDescription = currentQuest.GetCurrentStepDescription();
        Debug.Log($"���� �ܰ�: {currentStepDescription}");

        // UI �ؽ�Ʈ ������Ʈ
        if (questText != null)
        {
            questText.text = $"���� ����Ʈ �ܰ�: {currentStepDescription}";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompleteCurrentStep(); // ���� �ܰ� �Ϸ�
        }
    }
}
