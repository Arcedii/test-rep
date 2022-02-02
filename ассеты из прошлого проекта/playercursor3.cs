using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercursor3 : MonoBehaviour
{
    public Texture2D cursor;

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 25, 50, 50), cursor);
    }



}
