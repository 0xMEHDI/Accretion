using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollector : MonoBehaviour
{
    int coins = 0;
    int keys = 0;
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            keys++;
        }
    }

    public int GetCoinCount()
    {
        return coins;
    }

    public int GetKeyCount()
    {
        return keys;
    }
}
