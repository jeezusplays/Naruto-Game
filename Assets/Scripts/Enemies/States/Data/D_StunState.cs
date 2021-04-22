using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStunStateData", menuName = "Data/State Data/Stun State")]

public class D_StunState : ScriptableObject
{
    public float stunTime = 3f;
    public float knockbackTime = 0.2f;
    public float knockbackSpeed = 20f;

    public Vector2 knockbackAngle;
}
