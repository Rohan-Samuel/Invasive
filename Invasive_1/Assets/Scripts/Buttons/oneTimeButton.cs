using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeButton : MonoBehaviour
{

    public bool activated = false; 
    public GameObject lightBulb;
    public GameObject button;
    public GameObject buttonSound;

    public GameObject top, bottom;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "NearbyDude") Debug.Log("Detect Enemy");
        if((collision.gameObject.tag == "NearbyDude") && (activated == false))
        {
            buttonSound.SetActive(true);
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += button.gameObject.transform.up * Time.deltaTime * -20;
            
        }
    }
}
