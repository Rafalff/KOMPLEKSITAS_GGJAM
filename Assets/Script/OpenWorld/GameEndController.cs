using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
	[SerializeField] private MonologueData data;
	private void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (GlobalGameManager.Instance.CheckFullItem())
			{
				Debug.Log("EndGame");
			}
			else {
				Debug.Log("Item Not Completed");
				
			}
			
		}
	}
}
