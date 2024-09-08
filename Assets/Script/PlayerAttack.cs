using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 
    void Update()
    {
        // Player 일반공격

        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("일반공격");
        }

        // 스킬 공격

        if (Input.GetKeyDown(KeyCode.E))
        {
            print("일반공격");
        }

        // 궁극기

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("긍극기");
        }
    }
}
