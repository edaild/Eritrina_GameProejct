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
                Debug.Log("���� ����");
            else if (CompareTag("spammo"))
                Debug.Log("Ư���� �Ѿ�");
            else if (CompareTag("madic"))
                Debug.Log("�޵�");
        }
    }
}
