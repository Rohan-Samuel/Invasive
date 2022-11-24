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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer.Equals(7))
        {
            activated = true;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += new Vector3(0,-1,0);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer.Equals(7))
        {
            activated = false;
            lightBulb.gameObject.GetComponent<LightToggle>().toggleColor();
            button.gameObject.transform.position += new Vector3(0,1,0);
        }
    }
}
