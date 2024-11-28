using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera01 : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

  
    void Update()
    {
        transform.position = transform.position + offset;
    }
}
