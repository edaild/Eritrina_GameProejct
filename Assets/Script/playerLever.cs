using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerLever : MonoBehaviour
{
    public float playerLever_count = 1;
    public Text playerLever_text;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            playerLever_count += 1;

            if (playerLever_count >= 60)
            {
                print("축하합니다. 최대 60레벨을 달성 하셔습니다.");

               if (playerLever_count > 60)
                {
                    print("더 이상은 점수를 올릴수 없습니다.");

                    playerLever_count = 60;
                }
            }
        }
        playerLever_text.text = "Lever " + playerLever_count;
    }
}
