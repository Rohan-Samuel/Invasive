using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player"){
            gameObject.GetComponent<StealthHandler>().setSound(2);
        }
    }
    private void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == "Player"){
            gameObject.GetComponent<StealthHandler>().setSound(0);
        }
    }
}
