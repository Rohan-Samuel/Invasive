using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioLogDisplay : MonoBehaviour
{
    public GameObject audioLog1, audioLog2, audioLog3, audioLog4, audioLog5;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && active == true) modifyDisplay(0);
    }
    public void modifyDisplay(int i){

        audioLog1.GetComponent<Image>().enabled = false;
        audioLog2.GetComponent<Image>().enabled = false;
        audioLog3.GetComponent<Image>().enabled = false;
        audioLog4.GetComponent<Image>().enabled = false;
        audioLog5.GetComponent<Image>().enabled = false;

        if(i > 0){
            active = true;
            switch(i){
                case 1:
                    audioLog1.GetComponent<Image>().enabled = true;
                    break;
                case 2:
                    audioLog2.GetComponent<Image>().enabled = true;
                    break;
                case 3:
                    audioLog3.GetComponent<Image>().enabled = true;
                    break;
                case 4:
                    audioLog4.GetComponent<Image>().enabled = true;
                    break;
                case 5:
                    audioLog5.GetComponent<Image>().enabled = true;
                    break;
                default:
                    break;
            }
        }
        else{
            active = false;
        }
    }
}
