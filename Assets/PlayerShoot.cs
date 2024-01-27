using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawner; // Reference to the bullet spawner
    public Camera playerCamera; // Reference to the main camera

    void Update()
    {
        // Detect mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Call a method to shoot
            Shoot();
        }
    }

    void Shoot()
    {
        // Raycast from the camera to the ground
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Calculate direction from bullet spawner to the hit point
            Vector3 direction = hit.point - bulletSpawner.position;
            direction.Normalize();

            // Instantiate a bullet at the bullet spawner position
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);

            // Rotate the bullet to face the shooting direction
            bullet.transform.forward = direction;

            // Add force to the bullet (assuming you have a Rigidbody on your bulletPrefab)
            bullet.GetComponent<Rigidbody>().AddForce(direction * 20f, ForceMode.Impulse);

            // Destroy the bullet after a certain time (adjust as needed)
            Destroy(bullet, 10f);
        }
    }
}
