using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightChange : MonoBehaviour
{

    public Material redLight;
    public Material greenLight;
    public GameObject lightBulb;
    // Start is called before the first frame update
    void Start()
    {
        setLight(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setLight(int i){
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
