using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingHandle : MonoBehaviour
{
    public Transform cam;
    public Transform throwPoint;
    public GameObject objectToThrow;

    public int bottles = 0;
    public float throwForce;
    public float throwUpwardForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bottles >= 1){
                GameObject projectile = Instantiate(objectToThrow, throwPoint.position, cam.rotation);

                // get rigidbody component
                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

                // calculate direction
                //Vector3 forceDirection = cam.transform.forward;

                //RaycastHit hit;

                //if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
                //{
                //    forceDirection = (hit.point - throwPoint.position).normalized;
                //}

                // add force
                Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

                projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

                bottles--;
            }
    }
    public void getBottle(){
        bottles++;
    }
}
