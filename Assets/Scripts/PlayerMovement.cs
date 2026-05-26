using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameSpeedData SpeedData;

    [SerializeField] float rayDistance = 1.2f;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayDistance, groundLayer);

        if (hit.collider != null)
        {
            Vector2 normal = hit.normal;

            // stabilize flat ground
            if (Vector2.Angle(normal, Vector2.up) < 1f)
                normal = Vector2.up;

            // slope direction
            Vector2 slopeDir = new Vector2(normal.y, -normal.x).normalized;

            Vector2 targetVelocity = slopeDir * SpeedData.PlayerSpeed;

            // smooth movement
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, 0.25f);

            // rotate to slope
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg - 90f;

            rb.MoveRotation(
                Mathf.LerpAngle(rb.rotation, angle, 12f * Time.fixedDeltaTime)
            );
        }
        else
        {
            // air / no ground
            rb.linearVelocity = new Vector2(SpeedData.PlayerSpeed, rb.linearVelocity.y);
        }
    }
}