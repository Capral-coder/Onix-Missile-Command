using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    public static int activeHouses = 4;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rocket"))
        {
            activeHouses--;
            Destroy(gameObject);

            if (activeHouses <= 0)
            {
                RocketSpawner.instance.ShowGameOver();
            }
        }
    }
}
