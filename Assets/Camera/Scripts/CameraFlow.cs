using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    public float offset = -10;
    [SerializeField]
    public float smoothSpeed = 0.05f;

    private void Awake()
    {
        if (player is null)
            Debug.LogWarning("Player position is not assigned to camera");
    }

    private void LateUpdate()
    {
            Vector2 smoothedPosition = Vector2.Lerp(transform.position, player.position, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
    }
}
