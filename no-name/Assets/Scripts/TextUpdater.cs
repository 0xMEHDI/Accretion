using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
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
        text.text = "Coins: " + coinCount + "\r\n" + "Keys: " + keyCount;
    }
}
