using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeButtonUnit : MonoBehaviour
{

    public bool activated = false; 
    public GameObject lightBulb;
    public GameObject button;
    public GameObject buttonSound;
    public GameObject gateSound;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound.SetActive(false);
        gateSound.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.layer.Equals(7) ||  (collision.gameObject.tag == "Player")) && (activated == false))
        {
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += new Vector3(0,-1,0);
            buttonSound.SetActive(true);
            gateSound.SetActive(true);
        }
        else{
            buttonSound.SetActive(false);
            gateSound.SetActive(false);
        }
    }
}
