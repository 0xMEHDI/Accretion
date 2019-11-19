using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollector : MonoBehaviour
{
    int coins = 0;
    int keys = 0;
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coins++;
        }
        else if (collision.tag == "Key")
        {
            Destroy(collision.gameObject);
            keys++;
        }
    }

    public int getCoinCount()
    {
        return coins;
    }

    public int getKeyCount()
    {
        return keys;
    }
}
