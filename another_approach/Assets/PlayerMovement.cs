using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpXForce = 5f;
    public float jumpYForce = 6f;
    public float skipXForce = 8f;
    public float skipYForce = 6f;

    public Rigidbody2D rb;
    private bool isGrounded;

    private PlanetBatchSpawner spawner; // Reference to your spawner script

    void Start()
    {
        spawner = FindObjectOfType<PlanetBatchSpawner>(); // Automatically finds the spawner in the scene
    }

    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                Jump(jumpXForce, jumpYForce);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                Jump(skipXForce, skipYForce);
        }
    }

    void Jump(float xForce, float yForce)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
        isGrounded = false;

        // 🌍 Spawn 3 new planets after jump
        if (spawner != null)
            spawner.SpawnThreePlanets();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            isGrounded = true;
        }
    }
}
