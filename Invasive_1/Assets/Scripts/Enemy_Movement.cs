using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject _bullet;
    public float obstacleRange = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast (ray, 0.75f, out hit)){
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerInfo>()){
                if(_bullet==null){
                    _bullet = Instantiate (bulletPrefab) as GameObject;
                    _bullet.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
                    _bullet.transform.rotation = transform.rotation;

                } else if(hit.distance < obstacleRange){
                    float angle = Random.Range (-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
        
    }
}
