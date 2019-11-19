using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    //fetch player + damagehandler

    CollectableCollector collector;
    Text text;

    int coinCount;
    int keyCount;

    void Start()
    {
        collector = FindObjectOfType<CollectableCollector>();
        text = GetComponent<Text>();
    }

    void Update()
    {
        coinCount = collector.getCoinCount();
        keyCount = collector.getKeyCount();
        // get then update player health
        text.text = "Coins: " + coinCount + "\r\n" + "Keys: " + keyCount + "\r\n" + "Health: ";
    }
}
