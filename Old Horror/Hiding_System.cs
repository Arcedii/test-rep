using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding_System : MonoBehaviour {
    public GameObject Player;
    public GameObject Hiding_image;
    public GameObject AI;
    public GameObject StandPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AI = GameObject.FindGameObjectWithTag("AI");
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Hiding_image.SetActive(true);
            AI.gameObject.GetComponent<AI_Behavior>().Target = StandPoint;
            Player.GetComponent<Crouch_Player>().CantStand = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Hiding_image.SetActive(false);
            Player.GetComponent<Crouch_Player>().CantStand = false;
        }
    }
}