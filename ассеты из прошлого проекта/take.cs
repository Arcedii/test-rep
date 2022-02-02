using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take : MonoBehaviour
{
    public cursore cursor;
    public GameObject FLight;
    public flashlight2 FL;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cursor.cOn == true && cursor.distance == true)
        {
            if (gameObject.CompareTag("Battery"))
            {
                FL.power += 50;
            }
            if (gameObject.CompareTag("Flashlight"))
            {
                FLight.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
