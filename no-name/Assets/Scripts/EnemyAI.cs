using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float lockOnSpeed = 2f;
    [SerializeField] float lockOnDistance = 5f;

    Transform player;
    Rigidbody2D rb2d;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(player.position.x - rb2d.position.x) <= lockOnDistance && Mathf.Abs(player.position.y - rb2d.position.y) <= lockOnDistance)
        {
            Vector2 target = new Vector2(player.position.x, rb2d.position.y);
            rb2d.position = Vector2.MoveTowards(rb2d.position, target, lockOnSpeed * Time.deltaTime);
        }
    }
}
