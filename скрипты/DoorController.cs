using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    Button but;
    [SerializeField]
    Button but1;

    public float distance = 2f;
    public static Action OnKeyFound;
    
    List<Key> keyList;

    void Start()
    {
        but.onClick.AddListener(OpenDoor);
        but1.onClick.AddListener(OpenDoor);
        keyList = new List<Key>();

    }


    void OpenDoor()
    {

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "Door")
            {
                Door door = hit.collider.GetComponent<Door>();
                if (door.isLocked)
                {
                    for (int i = 0; i < keyList.Count; i++)
                    {
                        if (keyList[i].id == door.id)
                        {
                            door.isLocked = false;
                            door.isOpen = !door.isOpen;
                            keyList.Remove(keyList[i]);
                        }
                        else
                        {

                            Debug.Log("Не тот ключ");
                        }
                    }
                }

                
                

            }
            if (hit.collider.GetComponent<Key>())
            {
                OnKeyFound?.Invoke();
                Key key = hit.collider.GetComponent<Key>();
                keyList.Add(key);
                Debug.Log(keyList.Count);
                Destroy(key.gameObject);
            }


        }

     }
}
