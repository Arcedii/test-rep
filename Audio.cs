using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource AudioSource;
    string noteTag = "Player";
    void Start()
    {
         AudioSource = gameObject.GetComponent<AudioSource>();
    }

  
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(noteTag))
        {

            AudioSource.enabled =true;
            AudioSource.Play();
        }
    }
    void OnCollisionExit(Collision other)
    {
        AudioSource.enabled =false;
        AudioSource.Stop();
    }
}
