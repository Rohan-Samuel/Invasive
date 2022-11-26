using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineKiller : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Crate")
        {
            Destroy(gameObject);
        }
    }
}
