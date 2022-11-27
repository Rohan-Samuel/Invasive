using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSeeing : MonoBehaviour
{   
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

    public void seekOut(Transform playerLoc, int intensity){
        enemy.GetComponent<FollowScript>().setTarget(playerLoc, intensity);
    }



    
}
