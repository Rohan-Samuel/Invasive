using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RNS
{
    public class PlayerStat : MonoBehaviour
    {
        public const int MAX_OXYGEN = 100;
        public const int MIN_OXYGEN = 40;
        public const double OXYGEN_REGEN = .2;
        public float oxygen = 70;
        public float savedOxygen = 0;
        public Slider oxygenBar;
        public bool isAlive;
        public bool killed;
        public int audioLogs = 0;
        Vector3 respawnLocation;
        Vector3 originalPos;
        public AudioSource audioSource;
        public bool isGainingO2 = false;
        public AudioClip audioLog0;

        public Transform cam;
        public Transform throwPoint;
        public GameObject objectToThrow;

        public int bottles = 3;
        public float throwForce;
        public float throwUpwardForce;
        // Start is called before the first frame update
        void Start()
        {
            originalPos = gameObject.transform.position;
            oxygenBar.value = oxygen;
            Debug.Log(oxygen);
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isGainingO2){
                oxygen= oxygen + (float)OXYGEN_REGEN;
                if(oxygen > MAX_OXYGEN){
                    oxygen = MAX_OXYGEN;
                }
            }

            if (oxygen > 0)
            {
                oxygen -= Time.deltaTime*1;
                isAlive = true;
            }
            oxygenBar.value = oxygen;

            if (oxygen <=0)
            {
                isAlive = false;
            }
            //Debug.Log(isAlive);//

            if (isAlive == false || killed == true)
            {
                OnDeath();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && bottles >= 1){
                GameObject projectile = Instantiate(objectToThrow, throwPoint.position, cam.rotation);

                // get rigidbody component
                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

                // calculate direction
                Vector3 forceDirection = cam.transform.forward;

                RaycastHit hit;

                if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
                {
                    forceDirection = (hit.point - throwPoint.position).normalized;
                }

                // add force
                Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

                projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

                bottles--;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer.Equals(7))
            {
                killed = true;
                Debug.Log("Touched");
                OnDeath();
            }
            else if (collision.gameObject.layer.Equals(11))
            {
                Debug.Log("Got Audio Log");
                audioSource.PlayOneShot(audioLog0, 0.5f);
            }
            else if (collision.gameObject.layer.Equals(6))
            {
                Debug.Log("Got Battery");
            }
            else if (collision.gameObject.tag == "Beaker"){
                bottles++;
            }
        }

        private void OnTriggerExit(Collider collision){
            if(collision.tag == "Oxygen")
            {
                isGainingO2 = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Oxygen")
            {
                isGainingO2 = true;

            }
                        
            else if(other.tag == "Respawn")
            {
                respawnLocation = gameObject.transform.position;
                savedOxygen = oxygen;
            }
        }


        private void OnDeath()
        {
            oxygen = savedOxygen;
            if (oxygen < MIN_OXYGEN)oxygen = MIN_OXYGEN;

            gameObject.transform.position = respawnLocation;
            if (gameObject.transform.position == respawnLocation)
            {
                killed = false;
            }
        }


    }
}