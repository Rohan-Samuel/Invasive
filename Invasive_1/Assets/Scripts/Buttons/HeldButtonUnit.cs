using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldButtonUnit : MonoBehaviour
{

    public bool activated = false; 
    public GameObject lightBulb;
    public GameObject button;
    public GameObject buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if((collision.gameObject.tag == "NearbyDude") |  (collision.gameObject.tag == "NearPlayer"))
        {
            buttonSound.SetActive(true);
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * -20;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if((collision.gameObject.tag == "NearbyDude") |  (collision.gameObject.tag == "NearPlayer"))
        {
            activated = false;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * 20;
        }
    }
}
