using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnHit : MonoBehaviour
{
    public GameObject brokenBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision co){
        if(co.gameObject.tag == "VenusFlyHitbox"){
            Instantiate(brokenBox, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
