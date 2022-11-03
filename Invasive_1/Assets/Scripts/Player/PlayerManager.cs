using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNS
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator anim;

        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            inputHandler.isInteracting = anim.GetBool("isInteracting");
        }
    }
}