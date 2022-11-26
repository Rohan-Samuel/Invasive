using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBreaker : MonoBehaviour
{
    public GameObject broken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        Transform area = transform;
        Instantiate(broken, area.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
