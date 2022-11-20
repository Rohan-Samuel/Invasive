using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightToggle : MonoBehaviour
{

    public Material redLight;
    public Material greenLight;
    public GameObject lightBulb;
    // Start is called before the first frame update
    void Start()
    {
        setColor(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setColor(int i){
        //red = 1
        if (i == 1){
            lightBulb.GetComponent<MeshRenderer>().material = redLight;
        }
        //green = 2
        else if (i == 2){
            lightBulb.GetComponent<MeshRenderer>().material = greenLight;
        }

    }
}
