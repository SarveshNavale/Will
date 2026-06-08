using UnityEngine;

public class FrontRangeMove : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float spriteWidth = 34.8f;

    void Update()
    {
        // Move left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // If completely behind camera, move ahead
        if (transform.position.x < cameraTransform.position.x - spriteWidth)
        {
            transform.position += Vector3.right * spriteWidth * 2f;
        }
    }
}