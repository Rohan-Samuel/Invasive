using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxHandler : MonoBehaviour
{
    public GameObject parent;
   // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Power")
        {

            parent.GetComponent<Boss>().health--;
        }
    }
}
