using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBlok : Npc
{
    [SerializeField] private bool isLari;
    [SerializeField] private int lariIndex;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator anim;

    [SerializeField] private List<Transform> waypoints;

    public void StartLari()
    {
        anim.SetBool("Lari", true);
        isLari = true;
        lariIndex = 0;
    }
	private void Update()
	{
        if (isLari)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[lariIndex].position, speed*Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[lariIndex].position) <= 0.25f)
            {
                if (lariIndex < waypoints.Count)
                {
                    lariIndex++;
                    Debug.Log("LanjutLari");
                }
                else {
                    Debug.Log("Kelar Lari");
                    isLari = false;
                }
            }
        }
	}
}
