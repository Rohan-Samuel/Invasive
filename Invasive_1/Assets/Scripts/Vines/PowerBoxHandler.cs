using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxHandler : MonoBehaviour
{
    public Boss boss;
    
    // public GameObject powSound;
   // Start is called before the first frame update
    public AudioSource audioSource; 
    public AudioClip audioSound;
    void Start()
    {
        // powSound.SetActive(false);
        boss = GetComponentInParent<Boss>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Power")
        {
            audioSource.PlayOneShot(audioSound, 0.5f);
            boss.health--;
            // powSound.SetActive(true);
        }
    }
}
