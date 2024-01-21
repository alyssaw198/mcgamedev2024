using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public float minY = -5f; // Minimum y-axis boundary
    public float maxY = -4f;  // Maximum y-axis boundary

    void OnMouseDown()
    {
        // Check if the mouse click is within the y-axis boundary
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Make sure the z-coordinates match
        if (mousePosition.y >= minY && mousePosition.y <= maxY)
        {
            // Record the offset between the object's position and the mouse position
            offset = transform.position - mousePosition;
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Get the current mouse position and convert it to world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Apply the offset to calculate the new position
            Vector3 newPosition = new Vector3(mousePosition.x + offset.x, Mathf.Clamp(mousePosition.y + offset.y, minY, maxY), transform.position.z);

            // Set the object's position within the y-axis boundary
            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a specific tag
        if (collision.gameObject.CompareTag("Lighter") && gameObject.CompareTag("Elastic"))
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Instantiate a new asset or perform any other logic
            // Load the prefab from the Resources folder
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Fire");
            // Instantiate the prefab
            GameObject newAsset = Instantiate(prefab, collisionPoint, Quaternion.identity);
            newAsset.tag = "Fire";
        }
        if (collision.gameObject.CompareTag("Wires") && gameObject.CompareTag("Clock"))
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Instantiate a new asset or perform any other logic
            // Load the prefab from the Resources folder
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Time");
            // Instantiate the prefab
            GameObject newAsset = Instantiate(prefab, collisionPoint, Quaternion.identity);
            newAsset.tag = "Time";
        }
    }
}
