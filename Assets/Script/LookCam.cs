using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{

    public GameObject cam;

    void Update()
    {
        transform.rotation = cam.transform.rotation;
    }
}
