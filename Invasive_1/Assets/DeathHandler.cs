using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathHandler : MonoBehaviour
{
    public GameObject vine1, vine2, vine3;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
      

        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (vine1 == null && vine2 == null && vine3 == null)
        {
            animator.SetTrigger("OnDeath");
            SceneManager.LoadScene(2);

        }
    }
}
