using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNotes : MonoBehaviour
{
    public float distance;
    [SerializeField]
    private GameObject note;
    [SerializeField]
    Button but1;

    string noteTag = "Note";
    bool playerSeesNote = false;
    void Start()
    {
        note.SetActive(false);
        but1.gameObject.SetActive(false);

        but1.onClick.AddListener(ReadNote);
    }

    void Update()
    {
        but1.onClick.AddListener(ReadNote);

    }

    void ReadNote ()
    {
       if(playerSeesNote)
            note.SetActive(!note.activeSelf);

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(noteTag))
        {
            but1.gameObject.SetActive(true);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag(noteTag) == false) return;       
        Ray ray = Camera.main.ScreenPointToRay(pos: (Vector3)new Vector2(x: Screen.width / 2, y: Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.GetComponent<Note>())
            {
                playerSeesNote = true;
                but1.gameObject.SetActive(true);
            }
            else
            {
                playerSeesNote = false;
                but1.gameObject.SetActive(false);
            }
        }
    }
    void OnCollisionExit(Collision other)
    {      
            but1.gameObject.SetActive(false);
            note.SetActive(false);        
    }
}
