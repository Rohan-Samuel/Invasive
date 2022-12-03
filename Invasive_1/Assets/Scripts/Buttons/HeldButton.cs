using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldButton : MonoBehaviour
{

    public bool activated = false; 
    public GameObject lightBulb;
    public GameObject button;
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
        if(collision.gameObject.tag == "NearbyDude")
        {
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * -20;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "NearbyDude")
        {
            activated = false;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * 20;
        }
    }
}
