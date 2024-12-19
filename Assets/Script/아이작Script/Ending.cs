using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class Ending : MonoBehaviour
{
    public GameObject EndUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndUI.SetActive(true);
        }
    }

    public void OnButtonclick()
    {
        SceneManager.LoadScene("Mainscene");
    }
}
