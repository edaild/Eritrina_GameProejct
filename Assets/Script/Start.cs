using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public GameObject[] logog_Image = new GameObject[2];
    public float loding_Time = 3;
    
    void Update()
    {
        scene_skip();

    }


    private void scene_skip()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
