using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string title; // ����Ʈ ����
    public List<string> steps; // ����Ʈ �ܰ� ����Ʈ
    public int currentStep; // ���� �ܰ� �ε���
    public int experience; // �Ϸ� �� ��� ����ġ

    public Quest(string title, List<string> steps)
    {
        this.title = title;
        this.steps = steps;
        this.currentStep = 0;
        this.experience = 0;
    }
    public void CompleteStep()
    {
        if (currentStep < steps.Count) // ���� �ܰ谡 ��ȿ�� ���
        {
            currentStep++; // �ܰ� ����
            if (currentStep == steps.Count) // ��� �ܰ踦 �Ϸ��� ���
            {
                CompleteQuest(); // ����Ʈ �Ϸ�
            }
        }
    }

    // ����Ʈ �Ϸ� �� ȣ��Ǵ� �޼���
    private void CompleteQuest()
    {
        experience += 1000; // ����ġ �߰�
        Debug.Log($"����Ʈ '{title}' �Ϸ�! ����ġ {experience} ȹ��!"); // �Ϸ� �޽��� ���
    }

    // ���� �ܰ��� ������ ��ȯ�ϴ� �޼���
    public string GetCurrentStepDescription()
    {
        return currentStep < steps.Count ? steps[currentStep] : "����Ʈ�� �Ϸ�Ǿ����ϴ�."; // �ܰ� ���� ��ȯ
    }
}


