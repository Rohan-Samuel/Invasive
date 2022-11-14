using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject footSteps;
    void Start()
    {
        footSteps.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")  || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")){
            footsteps();
        }

        if (!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            StopFootsteps();
        }


    }

    void footsteps()
    {
        footSteps.SetActive(true);
    }

    void StopFootsteps()
    {
        footSteps.SetActive(false);
    }
}
