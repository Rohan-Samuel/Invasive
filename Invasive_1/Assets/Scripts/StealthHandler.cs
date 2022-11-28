using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthHandler : MonoBehaviour
{
    public int sound;
    public int sight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("Hearing"))
        {
            if(sound >= other.gameObject.GetComponent<VisionSeeing>().getLevel()){
                Debug.Log("I can hear you" + other.gameObject.GetComponent<VisionSeeing>().getLevel());
                other.gameObject.GetComponent<VisionSeeing>().seekOut(gameObject.transform, sound);
            }
        }
        else if (other.tag == ("NearbyVine"))
        {
                other.gameObject.GetComponent<VineHear>().setSound(gameObject.transform, sound);
        }
        else if (other.tag == ("Seeing"))
        {
            if(sight >= other.gameObject.GetComponent<VisionSeeing>().getLevel()){
                Debug.Log("I can see you" + other.gameObject.GetComponent<VisionSeeing>().getLevel());
                other.gameObject.GetComponent<VisionSeeing>().seekOut(gameObject.transform, sight);
            }
        }
    }

    public void setSound(int i){
        sound = i;
    }
    public void setSight(int i){
        sight = i;
    }
    
}
