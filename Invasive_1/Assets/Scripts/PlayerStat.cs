using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RNS
{
    public class PlayerStat : MonoBehaviour
    {
        public float oxygen;
        public Slider oxygenBar;
        public bool isAlive;
        public bool killed;
        Vector3 originalPos;

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
                oxygenBar.value = oxygen;
            }

            if(collision.gameObject.layer.Equals(7))
            {
                killed = true;
                Debug.Log("Touched");
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