using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCat : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Rigidbody bulletRb = collision.gameObject.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // Add force to the bullet's Rigidbody
                bulletRb.velocity = new Vector3(5f, 5f, 5f);
            }
            Destroy(this.gameObject);
        }
    }
}
