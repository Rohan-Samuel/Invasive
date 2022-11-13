using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSeeing : MonoBehaviour
{   
    readonly int HEARING = 1;
    readonly int SEEING = 2;

    public int sense;
    public int level;
    
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getLevel(){
        return level;
    }



    
}
