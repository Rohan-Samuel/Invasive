using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxHandler : MonoBehaviour
{
    public GameObject vines;
    // Start is called before the first frame update
    void Start()
    {
        vines = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(13))
        {

            Destroy(vines.gameObject);
        }
    }
}
