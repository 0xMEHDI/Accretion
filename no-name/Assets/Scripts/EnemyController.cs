using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Transform groundCheck;
    //[SerializeField] Transform wallLeftCheck;
    //[SerializeField] Transform wallRightCheck;

    Rigidbody2D rb2d;

    [SerializeField] bool movingLeft = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movingLeft)
        {

        }
        else 
        {
            movingLeft = false;
        }
    }
}
