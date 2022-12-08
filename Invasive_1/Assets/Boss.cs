using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boss : MonoBehaviour
{

    public int health = 3;
    public BoxCollider mouth;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mouth = GetComponentInChildren<BoxCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) 
        {
            OnDeath();
            
        }
    }

 


    void OnDeath()
    {
        animator.SetTrigger("OnDeath");
        gameObject.layer = 6;
        Invoke("LoadEndScene", 6);
        

    }

    void LoadEndScene()
    {
        SceneManager.LoadScene(8);
    }
}
