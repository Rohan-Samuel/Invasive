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

        // Start is called before the first frame update
        void Start()
        {
            
            oxygenBar.value = oxygen;
            Debug.Log(oxygen);
        }

        // Update is called once per frame
        void Update()
        {
            if (oxygen > 0)
            {
                oxygen -= Time.deltaTime*2;
            }
            oxygenBar.value = oxygen;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer.Equals(6))
            {
                oxygen += 10;
                oxygenBar.value = oxygen;
            }
        }
    }
}