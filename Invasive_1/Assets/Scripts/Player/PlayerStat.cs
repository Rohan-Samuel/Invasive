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

        //public GameObject oxSound;

        public TextMeshProUGUI oxygenText;
        public TextMeshProUGUI bottleText;
        public TextMeshProUGUI youDead;
        public TextMeshProUGUI youRespawn;
        public TextMeshProUGUI saveText;
        public TextMeshProUGUI pickupText;

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

        int activeAudioLog = 0;

        // Start is called before the first frame update
        void Start()
        {
            //oxSound.SetActive(false);
            youDead.text = "";
            youRespawn.text = "";
            pickupText.text = "";
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
            activeAudioLog--;
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                Screen.lockCursor = true;
                Cursor.visible = false;
            }
            if(activeAudioLog < 0){
                pickupText.text = "";
            }


            if (isGainingO2){
                oxygen= oxygen + OXYGEN_REGEN;
               // oxSound.SetActive(true);
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
            else if(other.gameObject.tag == "Respawn")
            {
                respawnLocation = gameObject.transform.position;
                savedOxygen = oxygen;
                savedBottles = gameObject.GetComponent<ThrowingHandle>().getBottleCount();
                saveText.text = "";
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
                saveText.text = "Saving...";
                respawnLocation = gameObject.transform.position;
                savedOxygen = oxygen;
                savedBottles = gameObject.GetComponent<ThrowingHandle>().getBottleCount();
            }
        }


        private void OnDeath()
        {

            gameObject.GetComponent<ThrowingHandle>().setBottle(savedBottles);
            youDead.text = "You Died";
            youRespawn.text = "Click to Respawn";
            anim.SetTrigger("OnDeath");
            //myTMP.text = "Click Anywhere to Respawn";

            StartCoroutine(DelayedRespawn(anim.GetCurrentAnimatorStateInfo(0).length));
         
            


        }

        IEnumerator DelayedRespawn(float _delay = 0)
        {
            yield return new WaitForSeconds(_delay);

            //myTMP.text = "";


            if (Input.GetMouseButton(0)) {
                gameObject.transform.position = respawnLocation;
                anim.Play("Blend Tree");

                if (gameObject.transform.position == respawnLocation)
                {
                    killed = false;
                    isAlive = true;
                    animatorHandler.canRotate = true;
                    youDead.text = "";
                    youRespawn.text ="";
                    oxygen = savedOxygen;
                    if (oxygen < MIN_OXYGEN)oxygen = MIN_OXYGEN;
                }
            }
        }

        public void Respawn()
        {
           
        }

        public void audioDisplayPopup(int i){
            if(i == 0)pickupText.text = "";
            else {
                
                pickupText.text = "Got Audio Log #" + i.ToString();
                activeAudioLog = 120;
            }
        }
    }
}