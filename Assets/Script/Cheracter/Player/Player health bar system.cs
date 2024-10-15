using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Playerhealthbarsystem : MonoBehaviour
{


    public GameObject DieImage;

    [SerializeField]
    private Slider healthBar;
    private float MaxHp = 100;
    private float curHp = 100;
    float imsi;

    private void Start()
    {
       
        healthBar.value = (float) curHp / (float) MaxHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            curHp  -= 50;
        }
        imsi = (float)curHp / (float)MaxHp;
        handleHp();
        Die();
    }
    private void handleHp()
    {
        healthBar.value = Mathf.Lerp(healthBar.value, imsi, Time.deltaTime * 10);

    }

    private void Die()
    {
        if (curHp <= 0)
        {
            DieImage.SetActive(true);
        }
    }
}
