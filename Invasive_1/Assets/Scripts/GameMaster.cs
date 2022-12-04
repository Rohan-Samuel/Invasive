using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject player;

    public GameObject redButton, blueButton, purpleButton;

    public static bool firstSpawn = true;
    public static int bottleCount;
    public static float savedOxygen;
    public static Vector3 respawnLocation;

    public static bool firstLight = false, secondLight = false, thirdLight = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!firstSpawn){
            player.gameObject.transform.position = respawnLocation;
            player.gameObject.GetComponent<ThrowingHandle>().setBottle(bottleCount);
            player.gameObject.GetComponent<RNS.PlayerStat>().oxygen = savedOxygen;

            if(firstLight){
                redButton.gameObject.GetComponent<oneTimeButton>().startAuto();
            }
            if(secondLight){
                blueButton.gameObject.GetComponent<oneTimeButtonBottle>().startAuto();
            }
            if(thirdLight){
                purpleButton.gameObject.GetComponent<HeldButtonUnit>().startAuto();
            }
        }
        else{
            firstSpawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(redButton.gameObject.GetComponent<oneTimeButton>().activated)firstLight = true;
        if(blueButton.gameObject.GetComponent<oneTimeButtonBottle>().activated)secondLight = true;
        if(purpleButton.gameObject.GetComponent<HeldButtonUnit>().activated)thirdLight = true;
    }
}
