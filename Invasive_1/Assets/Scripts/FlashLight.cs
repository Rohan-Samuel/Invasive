using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private GameObject follow;
    // Start is called before the first frame update
    void Start()
    {
        follow = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.transform.position;
        
    }
}
