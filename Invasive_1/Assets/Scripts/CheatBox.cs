using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatBox : MonoBehaviour
{
    public bool cheatsEnabled = false;
    int cheatCounter;

    public GameObject player;
    public Transform[] respawnPoints;
    public TextMeshProUGUI cheatText;
    // Start is called before the first frame update
    void Start()
    {
        cheatText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(cheatsEnabled){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                player.transform.position = respawnPoints[0].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2)){
                player.transform.position = respawnPoints[1].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3)){
                player.transform.position = respawnPoints[2].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha4)){
                player.transform.position = respawnPoints[3].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha5)){
                player.transform.position = respawnPoints[4].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha6)){
                player.transform.position = respawnPoints[5].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha7)){
                player.transform.position = respawnPoints[6].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha8)){
                player.transform.position = respawnPoints[7].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha9)){
                player.transform.position = respawnPoints[8].position;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha0)){
                player.GetComponent<RNS.PlayerStat>().oxygen = 100;
                player.GetComponent<ThrowingHandle>().bottles = 3;
            }
        }
        else{
            if(Input.GetKeyDown(KeyCode.D)){
                if(cheatCounter == 0){
                    cheatCounter++;
                }
                else{
                    cheatCounter = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.A)){
                if(cheatCounter == 1){
                    cheatCounter++;
                }
                else{
                    cheatCounter = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.R)){
                if(cheatCounter == 2){
                    cheatCounter++;
                }
                else{
                    cheatCounter = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.K)){
                if(cheatCounter == 3){
                    cheatCounter++;
                }
                else{
                    cheatCounter = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.N)){
                if(cheatCounter == 4){
                    cheatCounter++;
                }
                else{
                    cheatCounter = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.E)){
                if(cheatCounter == 5){
                    cheatCounter++;
                }
                else{
                    cheatCounter = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.S)){
                if(cheatCounter == 6 || cheatCounter == 7){
                    cheatCounter++;
                }
                else{
                    cheatCounter = 0;
                }
            }

            if (cheatCounter == 8){
                cheatsEnabled = true;
                cheatText.text = "Cheats Enabled";
            } 
        }

        
    }
}
