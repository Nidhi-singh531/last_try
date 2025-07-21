using UnityEngine;

public class SelfDestructPlanet : MonoBehaviour
{
    private bool countdownStarted = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!countdownStarted && collision.gameObject.CompareTag("Player"))
        {
            countdownStarted = true;
            Invoke("DestroyPlanet", 2f);
        }
    }

    void DestroyPlanet()
    {
        Destroy(gameObject);
    }
}
