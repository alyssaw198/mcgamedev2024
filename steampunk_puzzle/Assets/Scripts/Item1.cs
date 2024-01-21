using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToTeleport : MonoBehaviour
{
    public Vector3 targetPosition;
    public float touchCooldown = 0.5f;

    private float lastTouchTime;
    public int newLayer = 6;

    private void Update()
    {
        // Check for the space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if the player has touched the object in the last 'touchCooldown' seconds
            if (Time.time - lastTouchTime <= touchCooldown)
            {
                Debug.Log("Teleporting item!");
                TeleportToTargetPosition();
                gameObject.layer = newLayer;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider belongs to the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected.");
            lastTouchTime = Time.time;
        }
    }

    private void TeleportToTargetPosition()
    {
        // Set the object's position to the target position
        transform.position = targetPosition;
    }
}
