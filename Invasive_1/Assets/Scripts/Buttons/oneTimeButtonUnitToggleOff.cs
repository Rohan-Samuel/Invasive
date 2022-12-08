using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeButtonUnitToggleOff : MonoBehaviour
{

    public bool activated = true; 
    public GameObject lightBulb;
    public GameObject button;
    public GameObject buttonSound;

    public GameObject otherButton;

    
    public AudioSource audioSource; 
    public AudioClip audioSound;
    // Start is called before the first frame update
    void Start()
    {
       // buttonSound.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "NearPlayer") Debug.Log("Detect Player");
        if(collision.gameObject.tag == "NearbyDude") Debug.Log("Detect Enemy");
        
        if(((collision.gameObject.tag == "NearbyDude") | (collision.gameObject.tag == "NearPlayer")) && (activated == false))
        {
            //buttonSound.SetActive(true);
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * -20;

            otherButton.gameObject.GetComponent<oneTimeButtonUnitToggleOn>().otherButtonPressed();

            audioSource.PlayOneShot(audioSound, 0.5f);
        }
    }
    public void otherButtonPressed(){
        activated = false;
        button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * 20;
    }
}
