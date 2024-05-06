using UnityEngine;
using System.Collections;

public class RocketSpawner : MonoBehaviour
{
    public static RocketSpawner instance;
    public GameObject rocketPrefab;
    public Transform[] targets;
    public static float rocketSpeed = 2f;
    public int destroyedRockets = 0;
    public GameObject gameOver;

    private float spawnInterval = 8f;
    private int threshold = 10;

    private void Start()
    {
        instance = this;
        StartCoroutine(SpawnRockets());
    }

    private IEnumerator SpawnRockets()
    {
        while (true)
        {
            Transform randomTarget = FindRandomTarget();
            if (randomTarget != null)
            {
                GameObject newRocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);
                Vector3 direction = (randomTarget.position - newRocket.transform.position).normalized;
                Rigidbody2D rb = newRocket.GetComponent<Rigidbody2D>();
                rb.velocity = direction * rocketSpeed;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void IncreaseParameters()
    {
        if (spawnInterval != 0)
        {
            if (TankRocketController.GetDestroyedRocketsCount() >= threshold)
            {
                spawnInterval -= 1f;
                rocketSpeed += 0.5f;
                threshold += 10;
            }
        }
    }

    public void SetDestroyedRockets(int count)
    {
        destroyedRockets = count;
    }

    private Transform FindRandomTarget()
    {
        if (targets != null && targets.Length > 0)
        {
            return targets[Random.Range(0, targets.Length)];
        }
        else
        {
            return null;
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        Debug.Log("GAME OVER");
    }
}
