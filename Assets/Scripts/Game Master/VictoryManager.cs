using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public Text currencyText;

    void Start()
    {
        currencyText.text = "Currency Earned: " + GameMaster.currencyAmount; // Updates text on victory scene
    }
}
