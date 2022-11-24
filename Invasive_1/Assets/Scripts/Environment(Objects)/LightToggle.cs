using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightToggle : MonoBehaviour
{

    public Material redLight;
    public Material greenLight;
    public GameObject lightBulb;

    public int activeColor;

    public GameObject boundDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        if (activeColor == 1){
            lightBulb.GetComponent<MeshRenderer>().material = redLight;
        }
        //green = 2
        else if (activeColor == 2){
            lightBulb.GetComponent<MeshRenderer>().material = greenLight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setColor(int i){
        //red = 1
        if (i == 1){
            lightBulb.GetComponent<MeshRenderer>().material = redLight;
            activeColor = 1;
            openDoor();
        }
        //green = 2
        else if (i == 2){
            lightBulb.GetComponent<MeshRenderer>().material = greenLight;
            activeColor = 2;
            closeDoor();
        }

    }
    public void toggleColor(){
        if (activeColor == 1){
            lightBulb.GetComponent<MeshRenderer>().material = greenLight;
            activeColor = 2;
            openDoor();
        }
        else if (activeColor == 2){
            lightBulb.GetComponent<MeshRenderer>().material = redLight;
            activeColor = 1;
            closeDoor();
        }
    }

    public void openDoor(){
        boundDoor.GetComponent<OpenMe>().openIt();
    }
    public void closeDoor(){
        boundDoor.GetComponent<OpenMe>().closeIt();
    }
}
