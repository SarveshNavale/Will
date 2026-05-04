using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] Transform cam;   // Drag Main Camera here

    [Header("Parallax Settings")]
    [SerializeField] float xMultiplier = 0.5f;
    [SerializeField] float yMultiplier = 0.3f;

    Vector3 targetPos;

    void LateUpdate()
    {
        if (cam == null) return;

        // Calculate target position based on camera
        targetPos = new Vector3(
            cam.position.x * xMultiplier,
            cam.position.y * yMultiplier,
            transform.position.z
        );

        // Direct follow (NO jitter)
        transform.position = targetPos;
    }
}