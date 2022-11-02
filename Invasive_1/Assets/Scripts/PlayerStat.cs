using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RNS
{
    public class PlayerStat : MonoBehaviour
    {
        public const int MAX_OXYGEN = 100;
        public const double OXYGEN_REGEN = .2;
        public float oxygen = 70;
        public Slider oxygenBar;
        public bool isAlive;
        public bool killed;
        public int audioLogs = 0;
        Vector3 respawnLocation;
        Vector3 originalPos;
        public AudioSource audioSource;
        public bool isGainingO2 = false;
        public AudioClip audioLog0;
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
                oxygen -= Time.deltaTime*2;
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
        }

        private void OnTriggerExit(Collider collision){
            if(collision.gameObject.layer.Equals(6))
            {
                isGainingO2 = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer.Equals(6))
            {
                isGainingO2 = true;

            }
                        
            else if(other.gameObject.layer.Equals(12))
            {
                respawnLocation = gameObject.transform.position;

            }
        }


        private void OnDeath()
        {
            oxygen = 70;
            gameObject.transform.position = respawnLocation;
            if (gameObject.transform.position == respawnLocation)
            {
                killed = false;
            }
        }


    }
}