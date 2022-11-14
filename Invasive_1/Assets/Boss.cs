using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onCollisionEnter(Collider c) {
        if (c.tag == "Power") {
            Destroy(gameObject);
        }
    }
}
