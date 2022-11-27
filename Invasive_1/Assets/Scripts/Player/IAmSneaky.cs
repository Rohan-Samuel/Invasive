using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmSneaky : MonoBehaviour
{
    public int VISUAL_STEALTH = 3;
    public int AUDIO_STEALTH = 2;

    bool lightOn = true;

    bool wDown = false, aDown = false, sDown = false, dDown = false, moving = false, crouching = false;
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
            crouching = true;
            gameObject.GetComponent<StealthHandler>().setSound(AUDIO_STEALTH);
            gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)){
            VISUAL_STEALTH++;
            AUDIO_STEALTH++;
            crouching = false;
            gameObject.GetComponent<StealthHandler>().setSound(AUDIO_STEALTH);
            gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
        }
        if (Input.GetKeyDown(KeyCode.F)){
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

        if (Input.GetKeyDown(KeyCode.W)){
            wDown = true;
        }
        if (Input.GetKeyDown(KeyCode.A)){
            aDown = true;
        }
        if (Input.GetKeyDown(KeyCode.S)){
            sDown = true;
        }
        if (Input.GetKeyDown(KeyCode.D)){
            dDown = true;
        }
        if (Input.GetKeyUp(KeyCode.W)){
            wDown = false;
        }
        if (Input.GetKeyUp(KeyCode.A)){
            aDown = false;
        }
        if (Input.GetKeyUp(KeyCode.S)){
            sDown = false;
        }
        if (Input.GetKeyUp(KeyCode.D)){
            dDown = false;
        }

        if(!sDown && !wDown && !aDown && !dDown && moving){
            moving = false;
            VISUAL_STEALTH--;
            AUDIO_STEALTH--;
            gameObject.GetComponent<StealthHandler>().setSound(AUDIO_STEALTH);
            gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
        }
        else if ((sDown || wDown || aDown || dDown) && !moving){
            moving = true;
            VISUAL_STEALTH++;
            AUDIO_STEALTH++;
            gameObject.GetComponent<StealthHandler>().setSound(AUDIO_STEALTH);
            gameObject.GetComponent<StealthHandler>().setSight(VISUAL_STEALTH);
        }

    }
}
