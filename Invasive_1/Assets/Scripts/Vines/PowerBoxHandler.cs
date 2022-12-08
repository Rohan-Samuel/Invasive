using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxHandler : MonoBehaviour
{
    public Boss boss;
    
    // public GameObject powSound;
   // Start is called before the first frame update
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

            boss.health--;
            // powSound.SetActive(true);
        }
    }
}
