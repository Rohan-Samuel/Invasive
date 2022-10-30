using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RNS
{
    public class PlayerStat : MonoBehaviour
    {
        public const int MAX_OXYGEN = 70;
        public float oxygen = 70;
        public Slider oxygenBar;
        public bool isAlive;
        public bool killed;
        public int audioLogs = 0;
        Vector3 respawnLocation;
        Vector3 originalPos;
        public AudioSource audioSource;
        public AudioClip clip;

        // Start is called before the first frame update
        void Start()
        {
            originalPos = gameObject.transform.position;
            oxygenBar.value = oxygen;
            Debug.Log(oxygen);
        }

        // Update is called once per frame
        void Update()
        {
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
            if(collision.gameObject.layer.Equals(6))
            {
                oxygen += 10;
                if(oxygen > MAX_OXYGEN){
                    oxygen=MAX_OXYGEN;
                }
                oxygenBar.value = oxygen;
            }


            else if(collision.gameObject.layer.Equals(7))
            {
                killed = true;
                Debug.Log("Touched");
                OnDeath();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer.Equals(6))
            {
                oxygen += 25;
                if(oxygen > MAX_OXYGEN){
                    oxygen=MAX_OXYGEN;
                }
                oxygenBar.value = oxygen;

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