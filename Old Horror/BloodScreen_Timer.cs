using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodScreen_Timer : MonoBehaviour {
    public Image image;
    private float timer;
    private float A;

	// Use this for initialization
	void Start () {
        A = 1f;
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, A);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        image.color = new Color(image.color.r, image.color.g, image.color.b, A);
        timer += 1 * Time.deltaTime;
            if (timer >= 0.1f)
            {
                A -= 0.05f;
                timer = 0;
            }
       
            if (A < 0.05f && A > 0.001f)
            {
                A = 1f;
                gameObject.SetActive(false);
            }
    }
}