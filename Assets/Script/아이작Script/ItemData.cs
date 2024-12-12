using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Text 컴포넌트를 사용하려면 이 네임스페이스가 필요합니다.

public class ItemData : MonoBehaviour
{
    public Playerhealthbarsystem playerhealthbarsystem;

    public int pieceCount = 0;  // 조각의 개수를 저장

    public bool pieceCheck;     // 조각 아이템을 체크하는 변수
    public bool spammoCheck;    // 스페셜 총알 체크 (현재는 사용되지 않음, 추후 구현 시 사용할 수 있음)
    public bool medicCheck;     // 메딕 체크

    public Text piecekeyCount;  // Text 컴포넌트 사용 (TextMeshProX가 아닌 Text)

    private void Start()
    {
        playerhealthbarsystem = FindObjectOfType<Playerhealthbarsystem>();
    }

    private void Update()
    {

        // 조각이 획득되면 pieceCount 증가
        if (pieceCheck)
        {
            pieceCount++;  // pieceCount 증가
            Debug.Log("조각 수 증가: " + pieceCount);
            pieceCheck = false;  // pieceCheck를 다시 false로 설정하여 한 번만 증가하도록 함
        }
        // 메딕 체크가 true일 때, 체력 회복
        else if (medicCheck)
        {
            if (playerhealthbarsystem.curHp < playerhealthbarsystem.MaxHp)
            {
                int healAmount = 100; // 체력 회복량
                playerhealthbarsystem.curHp += healAmount;

                // 체력이 최대치를 초과하지 않도록 설정
                if (playerhealthbarsystem.curHp > playerhealthbarsystem.MaxHp)
                {
                    playerhealthbarsystem.curHp = playerhealthbarsystem.MaxHp;
                }

                Debug.Log("체력 회복: " + healAmount);
            }
            medicCheck = false;  // medicCheck를 다시 false로 설정
        }
    }
}
