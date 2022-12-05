using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    bool pausing;
    
    public TextMeshProUGUI pauseText;
    // Start is called before the first frame update
    void Start()
    {
        pausing = false;
        pauseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !pausing){
            Screen.lockCursor = true;
            Cursor.visible = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pausing){
                Time.timeScale = 1;
                pausing = false;
                pauseText.text = "";
            }
            else{
                Time.timeScale = 0;
                pausing = true;
                Screen.lockCursor = false;
                Cursor.visible = true;
                pauseText.text = "PAUSED";
            }
        }
    }
}
