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
        public Slider chargeBar;
        public float savedOxygen = 0;
        public bool isGainingO2 = false;
        public int oxygenReading;

        public TextMeshProUGUI oxygenText;
        public TextMeshProUGUI bottleText;

        public bool isAlive;
        public bool killed;

        Vector3 respawnLocation;
        Vector3 originalPos;

        int savedBottles = 0;

        public Animator anim;
        public GameObject RespawnUI;
        public AnimatorHandler animatorHandler;
        public TextMeshProUGUI myTMP;

        public Rigidbody rigidbody;


        public int audioLogs = 0;
        public AudioSource audioSource; 
        public AudioClip audioLog0;

        public int UIBottles, UICharge;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponentInChildren<Animator>();
            rigidbody = GetComponent<Rigidbody>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();

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

            oxygenBar.value = oxygen;
            oxygenReading = (int)oxygen;
            oxygenText.text = oxygenReading.ToString();

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
                rigidbody.AddForce(Vector3.down * 10000);
                animatorHandler.canRotate = false;
                OnDeath();
            }

            UIBottles = gameObject.GetComponent<ThrowingHandle>().getBottleCount();
            UICharge = gameObject.GetComponent<ThrowingHandle>().getChargeCount();

            chargeBar.value = UICharge;
            bottleText.text = UIBottles.ToString();
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer.Equals(7))
            {
                killed = true;
                Debug.Log("Touched" + collision.gameObject.name);
                OnDeath();
            }
            else if (collision.gameObject.layer.Equals(11))
            {
                Debug.Log("Got Audio Log");
                //audioSource.PlayOneShot(audioLog0, 0.5f);
            }
            else if (collision.gameObject.layer.Equals(6))
            {
                Debug.Log("Got Battery");
            }
            //else if (collision.gameObject.tag == "Beaker"){
                //gameObject.GetComponent<ThrowingHandle>().getBottle();
            //}
        }

        private void OnTriggerExit(Collider other){
            if(other.gameObject.tag == "Oxygen")
            {
                isGainingO2 = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Oxygen")
            {
                isGainingO2 = true;

            }
                        
            else if(other.gameObject.tag == "Respawn")
            {
                respawnLocation = gameObject.transform.position;
                savedOxygen = oxygen;
                savedBottles = gameObject.GetComponent<ThrowingHandle>().getBottleCount();
            }
        }


        private void OnDeath()
        {
            oxygen = savedOxygen;
            if (oxygen < MIN_OXYGEN)oxygen = MIN_OXYGEN;
            gameObject.GetComponent<ThrowingHandle>().setBottle(savedBottles);

            anim.SetTrigger("OnDeath");
            myTMP.text = "Click Anywhere to Respawn";

            StartCoroutine(DelayedRespawn(anim.GetCurrentAnimatorStateInfo(0).length));
         
            


        }

        IEnumerator DelayedRespawn(float _delay = 0)
        {
            yield return new WaitForSeconds(_delay);

            myTMP.text = "";


            if (Input.GetMouseButton(0)) {
                gameObject.transform.position = respawnLocation;
                anim.Play("Blend Tree");

                if (gameObject.transform.position == respawnLocation)
                {
                    killed = false;
                    isAlive = true;
                    animatorHandler.canRotate = true;
                }
            }
        }

        public void Respawn()
        {
           
        }
    }
}