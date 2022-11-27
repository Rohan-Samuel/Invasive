using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkiplierE : MonoBehaviour
{
    Transform player;
    public MeshRenderer itsE;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        itsE.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            Vector3 doNotTurn = new Vector3(player.position.x, gameObject.transform.position.y, player.position.z);
            transform.LookAt(doNotTurn);
        }
    }

    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "NearPlayer"){
            player = collision.gameObject.transform;
            itsE.enabled = true;
        }
    }
    private void OnTriggerExit(Collider collision){
        if(collision.gameObject.tag == "NearPlayer"){
            player = collision.gameObject.transform;
            itsE.enabled = false;
        }
    }
    
}
