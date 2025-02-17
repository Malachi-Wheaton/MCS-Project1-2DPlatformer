using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public static Vector2 respawnPosition;

    void Start()
    {
        respawnPosition = transform.position; // Default respawn position
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            respawnPosition = transform.position; // Update respawn position when touching a checkpoint
        }
    }
}

