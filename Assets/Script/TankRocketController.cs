using UnityEngine;

public class TankRocketController : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;
    private Vector3 targetPosition;
    public ParticleSystem explosionParticles;
    private bool hasReachedTarget = false;

    public static int destroyedRockets = 0;

    public void SetDirection(Vector3 newDirection, Vector3 targetPos)
    {
        direction = newDirection;
        targetPosition = targetPos;
    }

    private void Update()
    {
        if (!hasReachedTarget)
        {
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                if (explosionParticles != null)
                {
                    explosionParticles.Play();
                }
                
                hasReachedTarget = true;
                destroyedRockets++;
                
                if (destroyedRockets >= 10)
                {
                    RocketSpawner.instance.IncreaseParameters();
                }

                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2f);
                foreach (Collider2D hitCollider in hitColliders)
                {
                    if (hitCollider.CompareTag("Rocket"))
                    {
                        Destroy(hitCollider.gameObject);
                    }
                }
            }
            else
            {
                transform.position += direction * speed * Time.deltaTime;
                transform.up = direction;
            }
        }
        else
        {
            Destroy(gameObject, explosionParticles.main.duration);
        }
    }

    public static int GetDestroyedRocketsCount()
    {
        return destroyedRockets;
    }
}
