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
            storytext.text = "한때, 메르헨이라는 이름을 가진 나는 여행 중 만난 소년과 함께\n 특별한 모험을 떠난 적이 있었다.";
        }
        if (itemData.pieceCount == 2)
        {
            storytext.text = "우리는 재앙으로 인해 심연에 오염된 꿈 세계를 구하기 위해 여러 고난을 함께 했다. \n 최악의 조건에서도 앞으로 나아갔다.";
        }
        if (itemData.pieceCount == 3)
        {
            storytext.text = "우리는 재앙의 장본인을 만났고 장본인을 쓰러트리기 위해\n 치열한 전투를 치렀다.";
        }
        if (itemData.pieceCount == 4)
        {
            storytext.text = "장본인을 쓰러트린 후 꿈 세계는 천천히 회복돼 가면\n 현실 세계 사람들도 일상생활에 지장이 없게 됐다.\n ...그리고 이제 이 꿈도 깰 때야 일어나...";
        }
    }
}
