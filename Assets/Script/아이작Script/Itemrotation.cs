using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ItemRot : MonoBehaviour
{
    public float rotationSpeed = 2f;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CompareTag("piece"))
                Debug.Log("유리 조각");
            else if (CompareTag("spammo"))
                Debug.Log("특별한 총알");
            else if (CompareTag("madic"))
                Debug.Log("메딕");
        }
    }
}
