using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public string InteractButton;

    public float interactDistance = 3f;
    public LayerMask interaLayer;

    public Image interactIcon;

    public bool isInteracting;

    // Start is called before the first frame update
    void Start()
    {
        if (interaction != null)
        {
            interactIcon.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if(isInteracting == false)
            {
                if(interactIcon != null)
                {
                    interactIcon.enabled = true; 
                }

                if(Input.GetButtonDown(interactButton))
                {
                    if(hit.collider.CompareTag("Note"))
                    {
                        hit.collider.GetComponent<Note>().ShowNoteImage(); 
                    }
                }
            }
        }
    }
}
