using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeButtonBottle : MonoBehaviour
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
    private void OnTriggerStay(Collider collision)
    {
        if(( (collision.gameObject.tag == "Throwable") ||  (collision.gameObject.tag == "LandedObject")) && (activated == false))
        {
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += new Vector3(0,-1,0);
        }
    }
}
