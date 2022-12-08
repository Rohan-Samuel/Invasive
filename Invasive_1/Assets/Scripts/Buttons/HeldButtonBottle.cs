using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldButtonBottle : MonoBehaviour
{

    public bool activated = false; 
    public GameObject lightBulb;
    public GameObject button;

    
    public AudioSource audioSource; 
    public AudioClip audioSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if((collision.gameObject.tag == "NearBottle"))
        {
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * -20;
            audioSource.PlayOneShot(audioSound, 0.5f);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if((collision.gameObject.tag == "NearBottle"))
        {
            activated = false;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * 20;
        }
    }
}
