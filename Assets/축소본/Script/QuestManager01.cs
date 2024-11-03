using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager01 : MonoBehaviour
{
    private Quest currentQuest;
    public Text questText; // 현재 퀘스트 단계 텍스트
    public GameManager gameManager; // GameManager 인스턴스

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager 찾기
        InitializeQuest(); // 퀘스트 초기화
        ShowCurrentStep(); // 현재 단계 보여주기
    }

    void InitializeQuest()
    {
        var steps = new List<string>
        {
            "앞의 있는 \n 미스터리 소녀와 대화하기",
            "일반공격 해보기",
            "메르헨하고 대화하기",
            "스킬 공격 해보기",
            "메르헨하고 대화하기",
            "궁극기 써보기",
            "메르헨하고 대화하기",
        };

        currentQuest = new Quest("튜토리얼 임무", steps);
        gameManager.mainQuestCount = currentQuest.currentStep; // 초기 퀘스트 단계 저장
    }

    public void CompleteCurrentStep()
    {
        currentQuest.CompleteStep();
        gameManager.mainQuestCount = currentQuest.currentStep; // 현재 퀘스트 단계 업데이트
        ShowCurrentStep();

        // 퀘스트 완료 시 경험치 출력
        if (currentQuest.GetCurrentStepIndex() == currentQuest.GetTotalSteps())
        {
            gameManager.AddExperience(currentQuest.experience);
            Debug.Log($"퀘스트 '{currentQuest.title}' 완료! 경험치 {currentQuest.experience} 획득!");
        }
    }

    void ShowCurrentStep()
    {
        string currentStepDescription = currentQuest.GetCurrentStepDescription();
        Debug.Log($"현재 단계: {currentStepDescription}");

        // UI 텍스트 업데이트
        if (questText != null)
        {
            questText.text = $"현재 퀘스트 단계: {currentStepDescription}";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompleteCurrentStep(); // 현재 단계 완료
        }
    }
}
