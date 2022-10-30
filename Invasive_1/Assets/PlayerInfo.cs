using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health=10;
        
    }

    public void Hurt(int damage){
        _health -= damage;
        Debug.Log("health :" + _health);
    }

}
