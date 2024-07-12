using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookAt : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0; // Optional: Keep the object oriented horizontally

            // Calculate the rotation to look at the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

            // Apply the rotation and correct for the flip by adding 180 degrees on the Y axis
            transform.rotation = lookRotation * Quaternion.Euler(0, 180, 0);
        }
    }
}
