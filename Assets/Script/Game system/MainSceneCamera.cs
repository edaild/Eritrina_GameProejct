using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainSceneCamera : MonoBehaviour
{
    public float rotatespeed = 0.05f;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, rotatespeed, 0));     
    }
}
