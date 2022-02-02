using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
   
    [SerializeField]
    Canvas DoorMessage;
    [SerializeField]
    float openDoor;
    [SerializeField]
    float closeDoor;
    float speed = 1;

    public bool isOpen;
    public bool isLocked;
    public int id;

    void Start()
    {
        DoorMessage.gameObject.SetActive(false);
    }

   
    void Update()
    {
       if (isOpen)
        {
            OpenDoor();
        }
       else
        {
            CloseDoor();
        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        DoorMessage.gameObject.SetActive(true);

    }
    private void OnCollisionExit(Collision collision)
    {
        DoorMessage.gameObject.SetActive(false);

    }


    void OpenDoor()
    {
       
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, openDoor, transform.rotation.z), speed * Time.deltaTime);

    }
    void CloseDoor()
    {
       
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, closeDoor, transform.rotation.z), speed * Time.deltaTime);

    }
    private void OnDestroy()
    {
              
        if (DoorMessage)
        {
            DoorMessage.gameObject.SetActive(false);
        }
        
       
    }
}
