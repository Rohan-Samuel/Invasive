using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle3UI : MonoBehaviour
{

    private GameObject player;
    private ThrowingHandle throwingHandle;
    RawImage beakerState;

    // Start is called before the first frame update
    void Start()
    {
        beakerState = GetComponent<RawImage>();
        player = GameObject.FindGameObjectWithTag("Player");
        throwingHandle = player.GetComponent<ThrowingHandle>();

    }

    // Update is called once per frame
    void Update()
    {
        if (throwingHandle.bottles <= 2)
        {
            beakerState.color = Color.black;
        }
        else
        {
            beakerState.color = Color.white;
        }
    }
}
