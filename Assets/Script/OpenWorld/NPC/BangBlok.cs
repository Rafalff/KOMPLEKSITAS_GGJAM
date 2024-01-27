using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBlok : Npc
{
    [SerializeField] private bool isLari;
    [SerializeField] private int lariIndex;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private Transform bangBlokTransform;
    [SerializeField] private PlayerDrunkController playerDrunkController;

    public void StartLari()
    {
        anim.SetBool("Lari", true);
        isLari = true;
        lariIndex = 0;
    }
	private void OnTriggerEnter(Collider other)
	{
        if (isLari)
        {
            if (other.transform.CompareTag("LompatTrigger"))
            {
                rb.velocity = new Vector3(0, jumpForce, 0);
                other.gameObject.SetActive(false);
                if (lariIndex < waypoints.Count-1)
                {
                    lariIndex++;
                    Debug.Log("LanjutLari");
                }
                else
                {
                    Debug.Log("Kelar Lari");
                    isLari = false;
                    playerDrunkController.ActivateTrigger();
                }
            }
        }
	}
	public void AddWaypoints(List<Transform> data)
    {
        waypoints = data;
        StartLari();
    }
	private void Update()
	{
        if (isLari)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[lariIndex].position, speed*Time.deltaTime);
            // Determine which direction to rotate towards
            Vector3 targetDirection = waypoints[lariIndex].position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = 40 * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
            if (Vector3.Distance(transform.position, waypoints[lariIndex].position) <= 0.25f)
            {
                if (lariIndex < waypoints.Count - 1)
                {
                    lariIndex++;
                    Debug.Log("LanjutLari");
                }
                else {
                    Debug.Log("Kelar Lari");
                    isLari = false;
                    anim.SetBool("Lari", false);
                    anim.SetTrigger("Modar");
                    playerDrunkController.ActivateTrigger();
                }
            }
          
        }
	}
}
