using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool pausing;
    // Start is called before the first frame update
    void Start()
    {
        pausing = false;
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
            }
            else{
                Time.timeScale = 0;
                pausing = true;
                Screen.lockCursor = false;
                Cursor.visible = true;
            }
        }
    }
}
