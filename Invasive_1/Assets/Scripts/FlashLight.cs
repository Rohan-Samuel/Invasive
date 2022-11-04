using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Transform follow;
    [SerializeField]
    float turnSpeed = 0.02f;
    
    // Start is called before the first frame update
    void Start()
    {
        follow = transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = follow.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-direction), turnSpeed * Time.deltaTime);

    }
}
