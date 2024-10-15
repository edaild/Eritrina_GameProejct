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
            Debug.Log("대화를 할려면 키보드 F 키를 누르세요");
            if (Input.GetKey(KeyCode.F))
            {

            }
        }
    }
}
