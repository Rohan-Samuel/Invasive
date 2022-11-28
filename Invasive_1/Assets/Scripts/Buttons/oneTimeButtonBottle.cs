using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeButtonBottle : MonoBehaviour
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
    private void OnTriggerStay(Collider collision)
    {

        if( (collision.gameObject.tag == "NearBottle")  && (activated == false))
        {
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += new Vector3(0,-1,0);
            buttonSound.SetActive(true);
        }
    }
}
