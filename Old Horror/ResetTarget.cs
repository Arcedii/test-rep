using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTarget : MonoBehaviour {
    private GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "AI")
        {
            other.gameObject.GetComponent<AI_Behavior>().Target = Player;
        }
    }
}