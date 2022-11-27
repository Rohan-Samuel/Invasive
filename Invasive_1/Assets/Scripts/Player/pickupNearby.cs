using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupNearby : MonoBehaviour
{
    public int nearbyBottles = 0;
    public int audioLogID = 0;
    public GameObject mainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(nearbyBottles > 0){
                for (int i = 0; i < nearbyBottles; i++){
                    mainPlayer.GetComponent<ThrowingHandle>().getBottle();
                }
                nearbyBottles = 0;
            }
            if(audioLogID > 0){
                audioLogID = 0;
            }
        }
    }

    public void pickupActivate(int value, int type){
        if(type == 0){
            nearbyBottles+=value;
        }
        else if (type == 1){
            audioLogID = value;
        }
    }

}
