using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Slider healthBar;

    public float MaxHp = 100;
    public float curHp = 100;

    private void Start()
    { 
        healthBar.value = curHp / MaxHp;
    }

    public void handleHp()
    {
        // 슬라이드를 부드럽게 줄여준다.
        healthBar.value = Mathf.Lerp(healthBar.value, curHp / MaxHp, Time.deltaTime * 10);
    }

}
