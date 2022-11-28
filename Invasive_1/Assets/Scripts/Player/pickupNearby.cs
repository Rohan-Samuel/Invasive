using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupNearby : MonoBehaviour
{
    public int nearbyBottles = 0;
    public int audioLogID = 0;
    public GameObject mainPlayer;

    public GameObject audioLogUIBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nearbyBottles == -69)nearbyBottles = 0;
        
        if(Input.GetKeyDown(KeyCode.E)){
            if(nearbyBottles > 0){
                int num;
                if(nearbyBottles > 3)num = 3;
                else num = nearbyBottles;

                for (int i = 0; i < num; i++){
                    mainPlayer.GetComponent<ThrowingHandle>().getBottle();
                }
                nearbyBottles = 0;
            }
            if(audioLogID > 0){
                audioLogUIBlock.GetComponent<RNS.PlayerStat>().audioDisplayPopup(audioLogID);
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
