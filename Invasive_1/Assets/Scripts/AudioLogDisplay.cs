using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioLogDisplay : MonoBehaviour
{
    public GameObject audioLog1, audioLog2, audioLog3, audioLog4, audioLog5;
    bool active = false;
    int readCounter = 0;
    public TextMeshProUGUI pauseText;
    // Start is called before the first frame update
    void Start()
    {
        pauseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        readCounter--;
        if(Input.GetKeyDown(KeyCode.E) && active == true && readCounter < 0) {
            modifyDisplay(0);
            pauseText.text = "";
        }
    }
    public void modifyDisplay(int i){

        

        audioLog1.SetActive(false);
        audioLog2.SetActive(false);
        audioLog3.SetActive(false);
        audioLog4.SetActive(false);
        audioLog5.SetActive(false);

        if(i > 0){
            active = true;
            readCounter = 30;
            switch(i){
                case 1:
                    audioLog1.SetActive(true);
                    pauseText.text = "Press E to Close";
                    break;
                case 2:
                    audioLog2.SetActive(true);
                    pauseText.text = "Press E to Close";
                    break;
                case 3:
                    audioLog3.SetActive(true);
                    pauseText.text = "Press E to Close";
                    break;
                case 4:
                    audioLog4.SetActive(true);
                    pauseText.text = "Press E to Close";
                    break;
                case 5:
                    audioLog5.SetActive(true);
                    pauseText.text = "Press E to Close";
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
