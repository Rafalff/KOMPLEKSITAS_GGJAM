using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
				SceneManager.LoadScene("Outro");
			}
			else {
				Debug.Log("Item Not Completed");
				OpenWorldManager.Instance.PlayMonologue(data);
			}
			
		}
	}
	
}
