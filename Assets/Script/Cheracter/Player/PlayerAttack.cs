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


    // 공격 함수 처리
    public void Attack(KeyCode attackKey)
    {
        if (Input.GetKey(attackKey))
        {
            switch (attackKey)
            {
                case KeyCode.UpArrow:
                    Debug.Log("위 방향 공격");
                    break;

                case KeyCode.DownArrow:
                    Debug.Log("아레 방향 공격");
                    break;

                case KeyCode.LeftArrow:
                    Debug.Log("왼쪽 방향 공격");
                    break;
                case KeyCode.RightArrow:
                    Debug.Log("오른쪽 방향 공격");
                    break;
            }
        }
    }
}
