using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public bool doorOn;
    public GameObject Door;
    public cursore cursor;
    public float TimeOut = 1;
    public bool OnTimeOut;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cursor.cOn == true && cursor.distance == true && TimeOut == 1)
        {
            if (doorOn == false)
            {
                Door.GetComponent<Animation>().CrossFade("open door");
            }
            else
            {
                Door.GetComponent<Animation>().CrossFade("close a door");
            }
            doorOn = !doorOn;
        }
        if(TimeOut > 0 && OnTimeOut == true)
        {
            TimeOut -= Time.deltaTime;
        }
        if(TimeOut <= 0)
        {
            OnTimeOut = false;
            TimeOut = 1;

        }
    }
}
