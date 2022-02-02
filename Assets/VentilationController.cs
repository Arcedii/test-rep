using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentilationController : MonoBehaviour
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
        but.onClick.AddListener(OpenVentilation);
        but1.onClick.AddListener(OpenVentilation);
        keyList = new List<Key>();

    }


    void OpenVentilation()
    {

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "ventilation")
            {
                Ventilation ventilation = hit.collider.GetComponent<Ventilation>();
                if (ventilation.isLocked)
                {
                    for (int i = 0; i < keyList.Count; i++)
                    {
                        if (keyList[i].id == ventilation.id)
                        {
                            ventilation.isLocked = false;
                            ventilation.isOpen = !ventilation.isOpen;
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
