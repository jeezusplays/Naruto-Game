using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;
    public BoxCollider2D colliderBounds;

    public Vector2 margin, smoothing;

    private Vector3 min, max;

    public bool isFollowing { get; set; }

    public void Start()
    {
        mainCamera = GetComponent<Camera>();

        min = colliderBounds.bounds.min; // Minimum world bound of box collider 2D
        max = colliderBounds.bounds.max; // Maximum world bound of box collider 2D

        isFollowing = true;
    }

    public void Update()
    {
        var x = transform.position.x; // Get x position of MainCamera
        var y = transform.position.y; // Get y position of MainCamera

        if (isFollowing)
        {
            if (Mathf.Abs(x - player.position.x) > margin.x) // If camera x position is more than margin x
                x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime); // Move camera along x axis

            if (Mathf.Abs(y - player.position.y) > margin.y) // If camera y position is more than margin y
                y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime); // Move camera along y axis
        }

        var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

        x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, min.y + mainCamera.orthographicSize, max.y - mainCamera.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z); // Update the position of the camera
    }
}
