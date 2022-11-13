using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip cracking;
    public int duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration--;
        if (duration == 0){
            Destroy(gameObject);
        }
    }
}
