using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMe : MonoBehaviour
{
    public bool open = false;

    public GameObject startPoint;
    public GameObject endPoint;

    public GameObject door;

    Transform target;

    public const int SPEED = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(open){
            target = endPoint.gameObject.transform;
        }
        else{
            target = startPoint.gameObject.transform;
        }
        //door.transform.position = target.position;
        door.transform.position = Vector3.MoveTowards(door.transform.position, target.position, SPEED/2 * Time.deltaTime);
    }
    
    public void openIt(){
        open = true;
    }

    public void closeIt(){
        open = false;
    }
}
