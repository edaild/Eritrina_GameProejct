using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float Player_Attack;
    

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Attack(KeyCode.UpArrow);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Attack(KeyCode.DownArrow);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Attack(KeyCode.LeftArrow);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Attack(KeyCode.RightArrow);
        }
    }


    // ���� �Լ� ó��
    public void Attack(KeyCode attackKey)
    {
        if (Input.GetKey(attackKey))
        {
            switch (attackKey)
            {
                case KeyCode.UpArrow:
                    Debug.Log("�� ���� ����");
                    break;

                case KeyCode.DownArrow:
                    Debug.Log("�Ʒ� ���� ����");
                    break;

                case KeyCode.LeftArrow:
                    Debug.Log("���� ���� ����");
                    break;
                case KeyCode.RightArrow:
                    Debug.Log("������ ���� ����");
                    break;
            }
        }
    }
}
