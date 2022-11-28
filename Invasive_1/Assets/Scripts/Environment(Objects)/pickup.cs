using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public Material standard, grabbable;

    public int pickupValue;

    public bool inRange = false;
    public bool consumable;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = standard;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inRange){
            if(consumable)Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision other){
        
    //    if (other.gameObject.tag == "Player")
    //        {
     //           Destroy(gameObject);
     //       }
    //}

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "NearPlayer"){
            inRange = true;
            gameObject.GetComponent<Renderer>().material = grabbable;
            if(pickupValue == 0){
                other.gameObject.GetComponent<pickupNearby>().pickupActivate(1,0);
            }
            else if (pickupValue == 69){
                other.gameObject.GetComponent<pickupNearby>().pickupActivate(69,0);
            }
            else{
                other.gameObject.GetComponent<pickupNearby>().pickupActivate(pickupValue,1);
            }
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "NearPlayer"){
            inRange = false;
            gameObject.GetComponent<Renderer>().material = standard;
            if(pickupValue == 0){
                other.gameObject.GetComponent<pickupNearby>().pickupActivate(-1,0);
            }
            else if (pickupValue == 69){
                other.gameObject.GetComponent<pickupNearby>().pickupActivate(-69,0);
            }
            else{
                other.gameObject.GetComponent<pickupNearby>().pickupActivate(0,1);
            }
        }
    }
}
