using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour
{
    [SerializeField]
    Canvas PlayerCanvas;
    [SerializeField]
    Image KeyBlue;

    void Start()
    {
        DoorController.OnKeyFound += EnableKeyImage;
    }

    
    void Update()
    {
        
    }

    void EnableKeyImage()
    {
        KeyBlue.enabled = true;
    }

}
