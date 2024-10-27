using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Quest currentQuest;

    void Start()
    {
        InitializeQuest(); // ����Ʈ �ʱ�ȭ
        ShowCurrentStep(); // ���� �ܰ� �����ֱ�
    }

    void InitializeQuest()
    {
        var steps = new List<string>
        {
            "���� �ӹ�1�� 1 �ӹ��Դϴ�.",
            "���� �ӹ�1�� 2 �ӹ��Դϴ�.",
            "���� �ӹ�1�� 3 �ӹ��Դϴ�.",
        };
        currentQuest = new Quest("���� �ӹ� 1��", steps);
    }

    public void CompleteCurrentStep()
    {
        currentQuest.CompleteStep();
        ShowCurrentStep();
    }

    void ShowCurrentStep()
    {
        Debug.Log($"���� �ܰ�: {currentQuest.GetCurrentStepDescription()}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompleteCurrentStep(); // ���� �ܰ� �Ϸ�
        }
    }
}