using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImageControl : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform component
    public float followSpeed = 2.0f; // Adjust this value to control the speed of background movement
    public float smoothingFactor = 0.5f; // Adjust this value to control the amount of lag

    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the desired position for the background based on the player's position
            Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);

            // Use Mathf.Lerp to smoothly interpolate between the current position and the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, followSpeed * smoothingFactor * Time.deltaTime);
        }
    }
}
