//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class QuestManager : MonoBehaviour
//{
//    private Quest currentQuest;
//    public Text questText; // 현재 퀘스트 단계 텍스트
//    public GameManger gameManger;

   
//   // public Text questTitleText; // 퀘스트 제목을 위한 텍스트

//    void Start()
//    {
//        gameManger = GetComponent<GameManger>();
//        InitializeQuest(); // 퀘스트 초기화
//        ShowCurrentStep(); // 현재 단계 보여주기
//    }

//    void InitializeQuest()
//    {
//        var steps = new List<string>
//        {
//            "앞의 있는 들떠있는 소녀와 대화하기",
//            "호텔에 들어가 데스크에 가서 체크인 하기",
//            "객실로 이동하기",

//        };

//        currentQuest = new Quest("메인 임무 1막", steps);
//        gameManger.mainQuestCount = currentQuest.currentStep; // 초기 퀘스트 단계 저장
//    }

//    public void CompleteCurrentStep()
//    {
//        currentQuest.CompleteStep();
//        gameManger.mainQuestCount = currentQuest.currentStep; // 현재 퀘스트 단계 업데이트
//        ShowCurrentStep();
//    }

//    void ShowCurrentStep()
//    {
//        string currentStepDescription = currentQuest.GetCurrentStepDescription();
//        Debug.Log($"현재 단계: {currentStepDescription}");

//        // UI 텍스트 업데이트
//        if (questText != null)
//        {
//            questText.text = currentStepDescription;
//        }

//        // 퀘스트 제목 업데이트 (옵션)
//        //if (questTitleText != null)
//        //{
//        //    questTitleText.text = currentQuest.title; // 퀘스트 제목 표시
//        //}
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            CompleteCurrentStep(); // 현재 단계 완료
//        }
//    }
//}
