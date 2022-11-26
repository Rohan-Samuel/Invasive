using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    bool lightOn = true;
    bool pressing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            if (!pressing){
                pressing = true;
                toggleLight();
            }
        }
        else {
            pressing = false;
        }
    }

    public void toggleLight(){
        lightOn = !lightOn;

        flashlight.enabled = lightOn;
    }
}
