using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursore : MonoBehaviour
{
    public Texture2D cursor;
    public bool distance;
    public bool cOn;
    void Start()
    {
        
    }

    
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2)
        {
            distance = true;
        }
        else
        {
            distance = false;
        }
    }
    private void OnMouseEnter()
    {
        cOn = true;
    }
    private void OnMouseExit()
    {
        cOn = false;
    }
    private void OnGUI()
    {
        if (distance == true && cOn == true)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 50, 50), cursor);
        }
    }
}
