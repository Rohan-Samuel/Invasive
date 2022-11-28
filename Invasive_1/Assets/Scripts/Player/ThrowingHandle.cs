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

    public int throwingCharge = 0;

    public GameObject aiming;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
             if (Input.GetKeyUp(KeyCode.Mouse0) && bottles >= 1){
                if(throwingCharge >= 60){
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

                    aiming.GetComponent<Crossair>().becomeHidden();
                    throwingCharge =0;   
                }
                else {
                    throwingCharge =0;    
                }
            }
        
        if (Input.GetKey(KeyCode.Mouse0) && bottles >= 1){
            throwingCharge++;

            if (throwingCharge >= 60){
                aiming.GetComponent<Crossair>().becomeVisible();
            }



        }

    }
    public void getBottle(){
        bottles++;
    }
    public void setBottle(int i){
        bottles = i;
    }
    public int getBottleCount(){
        return bottles;
    }
    public int getChargeCount(){
        return throwingCharge;
    }
}
