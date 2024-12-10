using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameStart : MonoBehaviour
{
  public void OnButtonClick_GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
