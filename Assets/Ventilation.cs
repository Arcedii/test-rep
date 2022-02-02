using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilation : MonoBehaviour
{
    [SerializeField]
    Canvas DoorMessage;
    [SerializeField]
    float openVentilation;
    [SerializeField]
    float closeVentilation;
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
            OpenVentilation();
        }
        else
        {
            CloseVentilation();
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


    void OpenVentilation()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, openVentilation, transform.rotation.z), speed * Time.deltaTime);

    }
    void CloseVentilation()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, closeVentilation, transform.rotation.z), speed * Time.deltaTime);

    }
    private void OnDestroy()
    {

        if (DoorMessage)
        {
            DoorMessage.gameObject.SetActive(false);
        }


    }
}
