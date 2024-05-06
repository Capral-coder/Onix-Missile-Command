using UnityEngine;

public class RocketController : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    private Transform target;

    private void Start()
    {

        target = FindRandomTarget();
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * RocketSpawner.rocketSpeed;
            transform.up = -direction;
        }
    }

    private Transform FindRandomTarget()
    {
        if (RocketSpawner.instance != null)
        {
            Transform[] targets = RocketSpawner.instance.targets;
            if (targets.Length > 0)
            {
                return targets[Random.Range(0, targets.Length)];
            }
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (explosionParticles != null)
            {
                ParticleSystem explosionEffect = Instantiate(explosionParticles, transform.position, Quaternion.identity);
                explosionEffect.Play();
                Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
            }
            gameObject.SetActive(false);
        }
    }
}
