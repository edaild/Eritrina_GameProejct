using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class tutorial : MonoBehaviour
{
    public GameObject textUI;
    public Text npcName;
    public Text textObject;
    public GameObject npcImags;
    public GameObject hpbar;
    public GameObject menuButton;
    public GameObject mainMenu;
    public int npc_clickCount = 0;
    public int text_Count = 0;
    public bool mouseClick;
    public float cs_time;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.tag == "NPC")
                {
                    textUI.SetActive(true);
                    hpbar.SetActive(false);
                    menuButton.SetActive(false);
                    npcName.text = "NPC 이름 입니다.";

                }

            }
        }
    }
}
