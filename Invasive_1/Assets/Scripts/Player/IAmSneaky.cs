using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmSneaky : MonoBehaviour
{
    public int VISUAL_STEALTH = 3;
    public int AUDIO_STEALTH = 2;

    bool lightOn = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<StealthHandler>().setSound(AUDIO_STEALTH);
        gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            VISUAL_STEALTH--;
            AUDIO_STEALTH--;
            gameObject.GetComponent<StealthHandler>().setSound(AUDIO_STEALTH);
            gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)){
            VISUAL_STEALTH++;
            AUDIO_STEALTH++;
            gameObject.GetComponent<StealthHandler>().setSound(AUDIO_STEALTH);
            gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
        }
        else if (Input.GetKeyDown(KeyCode.F)){
            if(lightOn){
                lightOn = false;
                VISUAL_STEALTH--;
                gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
            }
            else{
                lightOn = true;
                VISUAL_STEALTH++;
                gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
            }
        }
    }
}
