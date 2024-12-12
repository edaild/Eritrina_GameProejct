using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Text ������Ʈ�� ����Ϸ��� �� ���ӽ����̽��� �ʿ��մϴ�.

public class ItemData : MonoBehaviour
{
    public Playerhealthbarsystem playerhealthbarsystem;

    public int pieceCount = 0;  // ������ ������ ����

    public bool pieceCheck;     // ���� �������� üũ�ϴ� ����
    public bool spammoCheck;    // ����� �Ѿ� üũ (����� ������ ����, ���� ���� �� ����� �� ����)
    public bool medicCheck;     // �޵� üũ

    public Text piecekeyCount;  // Text ������Ʈ ��� (TextMeshProX�� �ƴ� Text)

    private void Start()
    {
        playerhealthbarsystem = FindObjectOfType<Playerhealthbarsystem>();
    }

    private void Update()
    {

        // ������ ȹ��Ǹ� pieceCount ����
        if (pieceCheck)
        {
            pieceCount++;  // pieceCount ����
            Debug.Log("���� �� ����: " + pieceCount);
            pieceCheck = false;  // pieceCheck�� �ٽ� false�� �����Ͽ� �� ���� �����ϵ��� ��
        }
        // �޵� üũ�� true�� ��, ü�� ȸ��
        else if (medicCheck)
        {
            if (playerhealthbarsystem.curHp < playerhealthbarsystem.MaxHp)
            {
                int healAmount = 100; // ü�� ȸ����
                playerhealthbarsystem.curHp += healAmount;

                // ü���� �ִ�ġ�� �ʰ����� �ʵ��� ����
                if (playerhealthbarsystem.curHp > playerhealthbarsystem.MaxHp)
                {
                    playerhealthbarsystem.curHp = playerhealthbarsystem.MaxHp;
                }

                Debug.Log("ü�� ȸ��: " + healAmount);
            }
            medicCheck = false;  // medicCheck�� �ٽ� false�� ����
        }
    }
}
