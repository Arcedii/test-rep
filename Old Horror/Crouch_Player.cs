using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch_Player : MonoBehaviour {
    private bool onCrouch;
    public bool CantStand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void useCrouch()
    {
        if (onCrouch == false)
        {
            gameObject.GetComponent<CapsuleCollider>().height = 0.2f;
            gameObject.GetComponent<CapsuleCollider>().radius = 0.2f;
            onCrouch = true;
        }
        else
        {
            if (CantStand == false)
            {
                gameObject.GetComponent<CapsuleCollider>().height = 4;
                gameObject.GetComponent<CapsuleCollider>().radius = 0.9326477f;
                onCrouch = false;
            }
        }
    }
}