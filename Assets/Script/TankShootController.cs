using UnityEngine;

public class TankShootController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject tankRocketPrefab;
    public float fireRate = 1f;
    private float nextFireTime;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = (mousePos - firePoint.position).normalized;
        GameObject tankRocket = Instantiate(tankRocketPrefab, firePoint.position, Quaternion.identity);
        tankRocket.GetComponent<TankRocketController>().SetDirection(direction, mousePos);
        nextFireTime = Time.time + fireRate;
    }
}
