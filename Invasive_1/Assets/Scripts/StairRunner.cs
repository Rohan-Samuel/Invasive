using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairRunner : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider coll){
        if(coll.gameObject.tag == "Stairs"){
            parent.gameObject.GetComponent<RNS.PlayerLocomotion>().setStairs(true);
        }
    }
    private void OnTriggerExit(Collider coll){
        if(coll.gameObject.tag == "Stairs"){
            parent.gameObject.GetComponent<RNS.PlayerLocomotion>().setStairs(false);
        }
    }
}
