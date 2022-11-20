using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RNS
{
    public class PlayerStat : MonoBehaviour
    {
        public const int MAX_OXYGEN = 100;
        public const int MIN_OXYGEN = 40;
        public const float OXYGEN_REGEN = .2f;
        public float oxygen = 70;
        public Slider oxygenBar;
        public float savedOxygen = 0;
        public bool isGainingO2 = false;
        public int oxygenReading;

        public TextMeshProUGUI oxygenText;

        public bool isAlive;
        public bool killed;

        Vector3 respawnLocation;
        Vector3 originalPos;

        public int audioLogs = 0;
        public AudioSource audioSource; 
        public AudioClip audioLog0;

        // Start is called before the first frame update
        void Start()
        {
            originalPos = gameObject.transform.position;
            oxygenBar.value = oxygen;
            oxygenReading = (int)oxygen;
            oxygenText.text = oxygen.ToString();
            audioSource = GetComponent<AudioSource>();
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
<<<<<<< Updated upstream

            oxygenBar.value = oxygen;
            oxygenReading = (int)oxygen;
            oxygenText.text = oxygenReading.ToString();
=======
           // oxygenReading = (int)oxygen;
           // oxygenText.text = oxygenReading.ToString();
>>>>>>> Stashed changes

            if (oxygen > 0)
            {
                oxygen -= Time.deltaTime*1;
                isAlive = true;
            }
            

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
            else if (collision.gameObject.layer.Equals(6))
            {
                Debug.Log("Got Battery");
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