using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RNS
{
    public class PlayerStat : MonoBehaviour
    {
        public const int MAX_OXYGEN = 100;
        public const float OXYGEN_REGEN = 1;
        public float oxygen = 70;
        public Slider oxygenBar;
        public bool isAlive;
        public bool killed;
        public int audioLogs = 0;
        Vector3 respawnLocation;
        Vector3 originalPos;
        public AudioSource audioSource;
        public AudioClip clip;
        public bool isGainingO2 = false;

        // Start is called before the first frame update
        void Start()
        {
            originalPos = gameObject.transform.position;
            oxygenBar.value = oxygen;
        }

        // Update is called once per frame
        void Update()
        {
            if (isGainingO2){
                oxygen= oxygen + OXYGEN_REGEN;
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
            gameObject.transform.position = originalPos;
            if (gameObject.transform.position == originalPos)
            {
                killed = false;
            }
        }


    }
}