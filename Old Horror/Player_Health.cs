using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    public GameObject Death_Panel;
    public Slider slider_Health;
    public int Health_bar;
    public bool onFear;
    public AudioClip Scream_Sound;
    public GameObject Blood_Screen;
    private float timerDeath;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Health_bar>=100)
        {
            Health_bar = 100;
        }
        if(onFear==true)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(Scream_Sound);
            Health_bar -= 25;
            Blood_Screen.SetActive(true);
            onFear = false;
        }
        slider_Health.value = Health_bar;
        if(Health_bar<=0)
        {
            Death_Panel.SetActive(true);
            gameObject.GetComponent<PlayerMoveController>().enabled = false;
            timerDeath += 1 * Time.deltaTime;
            if(timerDeath>=0.7f)
            {
                Time.timeScale = 0;
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
}