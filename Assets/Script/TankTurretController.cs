using UnityEngine;

public class TankTurretController : MonoBehaviour
{
    public Transform turret;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = (mousePos - turret.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        turret.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
