using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmeraController1 : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;
    private bool inTrigger;

    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }
    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cam1.enabled = !cam1.enabled;
                cam2.enabled = !cam2.enabled;
            }
        }
    }
    void OnTriggerEnter(Collider switch_camera1)
    {
        inTrigger = true;

    }
    void OnTriggerExit(Collider switch_camera1)
    {
        inTrigger = false;

    }
}
