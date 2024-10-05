using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    public Texture2D cursurIcon; // 마우스 아이콘
    void Start()
    {
        Cursor.SetCursor(cursurIcon, Vector2.zero, CursorMode.Auto);
    } 
}
