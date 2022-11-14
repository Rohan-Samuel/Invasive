using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineStat : MonoBehaviour
{
    public GameObject tip;
    public float Health; 
    // Start is called before the first frame update
    void Start()
    {
        Health = 3;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(13))
        {
            
            Debug.Log("Sparkspark");
            OnDeath();
        }
    }

    void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
