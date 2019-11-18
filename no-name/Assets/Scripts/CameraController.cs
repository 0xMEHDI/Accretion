using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController player;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);   
    }
}
