using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossair : MonoBehaviour
{
    private bool isVisible;
    public MeshRenderer thisRenderer;
    // Start is called before the first frame update
    void Start()
    {
        isVisible = false;
        thisRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void becomeVisible(){
        thisRenderer.enabled = true;
    }
    public void becomeHidden(){
        thisRenderer.enabled = false;
    }
}
