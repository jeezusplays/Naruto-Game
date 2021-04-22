using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 pos1, pos2; // Variables for the min and max positions the platform can move
    public float speed = 1.0f;

    void Update()
    {
        // Updates position of platform by interpolating between the 2 positions at set speed and time
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1, pos2); // Connects pos1 and pos2 by drawing a line on scene view
    }
}
