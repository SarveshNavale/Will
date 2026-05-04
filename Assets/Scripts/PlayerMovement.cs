using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] float rayDistance = 1.2f;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 origin = transform.position + Vector3.down * 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayDistance, groundLayer);

        if (hit.collider != null)
        {
            Vector2 normal = hit.normal;

            // filter micro slope noise
            if (Vector2.Angle(normal, Vector2.up) < 1f)
                normal = Vector2.up;

            Vector2 slopeDir = new Vector2(normal.y, -normal.x).normalized;

            Vector2 targetVelocity = slopeDir * speed;

            // smooth velocity (KEY FIX)
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, 0.25f);

            // smooth rotation
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg - 90f;

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(0, 0, angle),
                12f * Time.fixedDeltaTime
            );

            // ground snap (optional but powerful)
            transform.position = new Vector2(transform.position.x, hit.point.y + 0.5f);
        }
        else
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
    }
}