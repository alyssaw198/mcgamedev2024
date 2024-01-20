using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a specific tag
        if (collision.gameObject.CompareTag("Draggable"))
        {
            // Destroy both draggable objects
            Debug.Log("Collided with another Draggable!");
            Vector2 collisionPoint = collision.contacts[0].point;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Instantiate a new asset or perform any other logic
            InstantiateNewAsset(collisionPoint);
        }
    }

    // Example method to instantiate a new asset
    void InstantiateNewAsset(Vector2 position)
    {
        // Instantiate your new asset
        GameObject newAsset = Instantiate(Resources.Load<GameObject>("Prefabs/obj3"));

        newAsset.transform.position = position;

        Draggable newDraggable = newAsset.AddComponent<Draggable>();
    }
}
