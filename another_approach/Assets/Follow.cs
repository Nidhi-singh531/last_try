using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public Transform player;  // Assign the player's transform in the inspector
    public float smoothSpeed = 0.125f;

    private Vector3 offset;

    void Start()
    {
        // Initial offset from the player
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Only follow the player's X position
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
