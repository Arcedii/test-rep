using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject AI_Object;
    private int i = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i = PlayerPrefs.GetInt("CanSpawn");
        if (i == 1)
        {
            {
                Instantiate(AI_Object, gameObject.transform.position, Quaternion.identity);
                PlayerPrefs.SetInt("CanSpawn", 0);
                i = 0;
            }
        }
    }
}