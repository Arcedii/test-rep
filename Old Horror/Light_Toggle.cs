using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Light_Toggle : MonoBehaviour {

    public Light Light_FlashLight;
    public int AmountEnergy;
    public Text txtEnergy;
    public float RateDecrease;
    private bool on_FlashLight;
    private float timer_sec;
    public GameObject Button_Up;
    public int AddEnergy;
    public int AddHealth;
    private RaycastHit hit;
    private GameObject Player;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
    private void FixedUpdate()
    {
        var forw = transform.TransformDirection(Vector3.forward);
        //RaycastHit hit;

        if (Physics.Raycast(transform.position, forw, out hit, 3.5f))
        {
            if (hit.collider.tag == "AI")
            {
                if (Light_FlashLight.enabled == true)
                {
                    PlayerPrefs.SetInt("CanSpawn", 1);
                    Destroy(hit.collider.gameObject);
                }
            }
            if (hit.collider.tag == "Battery")
            {
                if (AmountEnergy < 100)
                {
                    Button_Up.SetActive(true);
                }
            }
            
            if (hit.collider.tag == "AIDkit")
            {
                if (Player.GetComponent<Player_Health>().Health_bar < 100)
                {
                    Button_Up.SetActive(true);
                }
            }
            if(hit.collider.tag != "Battery" && hit.collider.tag != "AIDkit")
            {
                Button_Up.SetActive(false);
            }
        }
        else
        {
            Button_Up.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
        
        if(AmountEnergy<=0)
        {
            AmountEnergy = 0;
            on_FlashLight = false;
        }
        if(AmountEnergy>=100)
        {
            AmountEnergy = 100;
        }
        txtEnergy.text = "ENERGY - " + AmountEnergy + "%";
        if(on_FlashLight==true)
        {
            timer_sec += 1 * Time.deltaTime;
            if(timer_sec >= RateDecrease)
            {
                AmountEnergy -= 1;
                timer_sec = 0;
            }
        }
    }
    public void TurnLight()
    {
        if(Light_FlashLight.enabled == false)
        {
            if (AmountEnergy > 0)
            {
                Light_FlashLight.enabled = true;
                on_FlashLight = true;
            }
        }
        else
        {
            Light_FlashLight.enabled = false;
            on_FlashLight = false;
        }
    }
    public void UseItem()
    {
        if (hit.collider.tag == "Battery")
        {
            AmountEnergy += AddEnergy;
            Destroy(hit.collider.gameObject);
        }
        if (hit.collider.tag == "AIDkit")
        {
            Player.GetComponent<Player_Health>().Health_bar += AddHealth;
            Destroy(hit.collider.gameObject);
        }
    }
}
