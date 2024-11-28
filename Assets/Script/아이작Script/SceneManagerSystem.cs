using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSystem : MonoBehaviour
{
    public int EnemyCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potar01"))
        {
            if (EnemyCount >= 2)
            {
                SceneManager.LoadScene("02Scene");
            }  
        }
        if (other.CompareTag("Potar02"))
        {
            if (EnemyCount >= 5)
            {
                SceneManager.LoadScene("03Scene");
            }
        }
        if (other.CompareTag("Potar03"))
        {
            if (EnemyCount >= 10)
            {
                SceneManager.LoadScene("04Scene");
            }
        }
        if (other.CompareTag("Potar04"))
        {
            if (EnemyCount >= 15)
            {
                SceneManager.LoadScene("05Scene");
            }
        }
        if (other.CompareTag("Potar05"))
        {
            if (EnemyCount >= 17)
            {
                SceneManager.LoadScene("06Scene");
            }
        }
    }
}
