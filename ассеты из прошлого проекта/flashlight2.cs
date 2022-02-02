using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight2 : MonoBehaviour
{
    public Light FL;
    public bool Onf;
    public Texture2D fon;
    public Texture2D line;
    public float power;
    public GUIStyle style;
    public bool PowerF;

    void Start()
    {
        
    }

   
    void Update()
    {  if (PowerF== true)
        {  if (Input.GetKeyDown(KeyCode.F))
            {
                Onf = !Onf;
        }   }
        if(Onf == true && power > 0)
        {
            power -= Time.deltaTime;
            FL.intensity = 2;
        }
        else
        {
            FL.intensity = 0;
        }
        if (power <= 0)
        {

            PowerF = false;
            Onf = false;
        }
    }
     private void OnGUI()
     {
        GUI.DrawTexture(new Rect(Screen.width / 2 - 570, Screen.height / 2 - 285, 240, 30), fon);
        GUI.DrawTexture(new Rect(Screen.width / 2 - 550, Screen.height / 2 - 280, power * 2, 20), line);
        GUI.Label(new Rect(Screen.width / 2 - 640, Screen.height / 2 - 280, 200, 20), "Power", style);
    }
}
