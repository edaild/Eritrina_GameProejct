using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public ItemData itemData ;
    public Text storytext;

    private void Start()
    {
        itemData = FindObjectOfType<ItemData>();
    }

    private void Update()
    {
        if(itemData.pieceCount == 1)
        {
            storytext.text = "�Ѷ�, �޸����̶�� �̸��� ���� ���� ���� �� ���� �ҳ�� �Բ�\n Ư���� ������ ���� ���� �־���.";
        }
        if (itemData.pieceCount == 2)
        {
            storytext.text = "�츮�� ������� ���� �ɿ��� ������ �� ���踦 ���ϱ� ���� ���� ���� �Բ� �ߴ�. \n �־��� ���ǿ����� ������ ���ư���.";
        }
        if (itemData.pieceCount == 3)
        {
            storytext.text = "�츮�� ����� �庻���� ������ �庻���� ����Ʈ���� ����\n ġ���� ������ ġ����.";
        }
        if (itemData.pieceCount == 4)
        {
            storytext.text = "�庻���� ����Ʈ�� �� �� ����� õõ�� ȸ���� ����\n ���� ���� ����鵵 �ϻ��Ȱ�� ������ ���� �ƴ�.\n ...�׸��� ���� �� �޵� �� ���� �Ͼ...";
        }
    }
}
