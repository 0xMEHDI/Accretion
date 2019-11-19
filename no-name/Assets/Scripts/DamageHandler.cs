using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
    //fetch player etc

    void Start()
    {

    }

    void Update()
    {
        KillPlayer();
    }

    private void KillPlayer()
    {
        //if player health = 0, reload scene
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // knockback, decrement player health
        }
    }
}
