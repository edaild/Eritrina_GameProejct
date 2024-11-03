using System.Collections.Generic;

[System.Serializable]
public class Quest
{
    public string title; // 퀘스트 제목
    public List<string> steps; // 퀘스트 단계 리스트
    public int currentStep; // 현재 단계 인덱스
    public int experience; // 완료 시 얻는 경험치

    public Quest(string title, List<string> steps)
    {
        this.title = title;
        this.steps = steps;
        this.currentStep = 0;
        this.experience = 0;
    }

    public void CompleteStep()
    {
        if (currentStep < steps.Count) // 현재 단계가 유효한 경우
        {
            currentStep++; // 단계 증가
            if (currentStep == steps.Count) // 모든 단계를 완료한 경우
            {
                CompleteQuest(); // 퀘스트 완료
            }
        }
    }

    private void CompleteQuest()
    {
        experience += 1000; // 경험치 추가
        // Debug.Log($"퀘스트 '{title}' 완료! 경험치 {experience} 획득!"); // 완료 메시지 출력
    }

    public string GetCurrentStepDescription()
    {
        return currentStep < steps.Count ? steps[currentStep] : "퀘스트가 완료되었습니다."; // 단계 설명 반환
    }

    public int GetCurrentStepIndex()
    {
        return currentStep;
    }

    public int GetTotalSteps()
    {
        return steps.Count;
    }
}
