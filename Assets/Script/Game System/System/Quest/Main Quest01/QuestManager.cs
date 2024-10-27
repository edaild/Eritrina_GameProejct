using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Quest currentQuest;

    void Start()
    {
        InitializeQuest(); // 퀘스트 초기화
        ShowCurrentStep(); // 현재 단계 보여주기
    }

    void InitializeQuest()
    {
        var steps = new List<string>
        {
            "메인 임무1막 1 임무입니다.",
            "메인 임무1막 2 임무입니다.",
            "메인 임무1막 3 임무입니다.",
        };
        currentQuest = new Quest("메인 임무 1막", steps);
    }

    public void CompleteCurrentStep()
    {
        currentQuest.CompleteStep();
        ShowCurrentStep();
    }

    void ShowCurrentStep()
    {
        Debug.Log($"현재 단계: {currentQuest.GetCurrentStepDescription()}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompleteCurrentStep(); // 현재 단계 완료
        }
    }
}