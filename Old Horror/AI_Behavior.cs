using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behavior : MonoBehaviour {
    public GameObject Target;
    public NavMeshAgent Self;
    private RaycastHit hit;

	// Use this for initialization
	void Start () {
        Self = gameObject.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player");
	}
    private void FixedUpdate()
    {
        var forw = transform.TransformDirection(Vector3.forward);
        //RaycastHit hit;

        if (Physics.Raycast(transform.position, forw, out hit, 5))
        {
            if (hit.collider.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<Player_Health>().onFear = true;
                PlayerPrefs.SetInt("CanSpawn", 1);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update () {
         Self.SetDestination(Target.transform.position);
	}
}