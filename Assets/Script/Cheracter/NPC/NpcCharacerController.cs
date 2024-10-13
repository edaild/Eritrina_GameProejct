using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCharacerController : MonoBehaviour
{
    [Header("NPC system")]

    public GameObject[] NpcCharacter;

    public GameObject fKeyUI;
    public float NpcSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // 각자 스크립트에서 상효작용이 진행된다. 물건일 경우 인벤토리 창에 추가 대화 일 경우 대화창 활성화
            }
        }
    }
}
