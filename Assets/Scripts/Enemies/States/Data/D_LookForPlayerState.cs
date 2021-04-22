using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLookForPlayerStateData", menuName = "Data/State Data/Look For Player State")]
public class D_LookForPlayerState : ScriptableObject // data container is use to save large amounts of data, independent of class instances
{
    // Create an integer for the amount of turns enemy should do
    public int amountOfTurns = 2;

    public float timeBetweenTurns = 0.5f;
}
