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

    private void OnCollisionStay(Collision collision){
        Transform area = transform;
        if (collision.gameObject.tag == "Terrain"){
            Instantiate(broken, area.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
