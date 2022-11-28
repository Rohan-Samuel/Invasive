using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineHear : MonoBehaviour
{
    public GameObject theVine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSound(Transform playerLoc, int intensity){
         theVine.GetComponent<RNS.VineAI>().setTarget(playerLoc, intensity);
    }
}
