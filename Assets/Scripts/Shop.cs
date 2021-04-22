using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text currency;

    void Start()
    {
        // Set the text for shop scene
        currency.text = Convert.ToString(PlayerPrefs.GetInt("currency"));
    }
}
