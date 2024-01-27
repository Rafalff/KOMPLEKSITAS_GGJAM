using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucingController : MonoBehaviour
{
    public GameObject tai;
    public GameObject nextKucing;
    private float startCount;
    public float endCount; // Make endCount a public variable if you want to set it from the Inspector

    private void Update()
    {
        if (startCount < endCount)
        {
            startCount += Time.deltaTime;
        }
        if (startCount >= endCount)
        {
            Instantiate(tai, transform.position, Quaternion.identity);
            KucingGameManager.instance.AddTai();
            Destroy(this.gameObject);
        }
    }

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
            Instantiate(nextKucing,transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
