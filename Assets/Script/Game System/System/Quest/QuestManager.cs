//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class QuestManager : MonoBehaviour
//{
//    private Quest currentQuest;
//    public Text questText; // ���� ����Ʈ �ܰ� �ؽ�Ʈ
//    public GameManger gameManger;

   
//   // public Text questTitleText; // ����Ʈ ������ ���� �ؽ�Ʈ

//    void Start()
//    {
//        gameManger = GetComponent<GameManger>();
//        InitializeQuest(); // ����Ʈ �ʱ�ȭ
//        ShowCurrentStep(); // ���� �ܰ� �����ֱ�
//    }

//    void InitializeQuest()
//    {
//        var steps = new List<string>
//        {
//            "���� �ִ� �鶰�ִ� �ҳ�� ��ȭ�ϱ�",
//            "ȣ�ڿ� �� ����ũ�� ���� üũ�� �ϱ�",
//            "���Ƿ� �̵��ϱ�",

//        };

//        currentQuest = new Quest("���� �ӹ� 1��", steps);
//        gameManger.mainQuestCount = currentQuest.currentStep; // �ʱ� ����Ʈ �ܰ� ����
//    }

//    public void CompleteCurrentStep()
//    {
//        currentQuest.CompleteStep();
//        gameManger.mainQuestCount = currentQuest.currentStep; // ���� ����Ʈ �ܰ� ������Ʈ
//        ShowCurrentStep();
//    }

//    void ShowCurrentStep()
//    {
//        string currentStepDescription = currentQuest.GetCurrentStepDescription();
//        Debug.Log($"���� �ܰ�: {currentStepDescription}");

//        // UI �ؽ�Ʈ ������Ʈ
//        if (questText != null)
//        {
//            questText.text = currentStepDescription;
//        }

//        // ����Ʈ ���� ������Ʈ (�ɼ�)
//        //if (questTitleText != null)
//        //{
//        //    questTitleText.text = currentQuest.title; // ����Ʈ ���� ǥ��
//        //}
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            CompleteCurrentStep(); // ���� �ܰ� �Ϸ�
//        }
//    }
//}
