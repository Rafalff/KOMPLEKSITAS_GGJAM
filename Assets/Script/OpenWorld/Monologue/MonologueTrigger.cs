using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    [SerializeField] private MonologueData data;
	[SerializeField] private bool alreadyTriggered;

	private void OnTriggerEnter(Collider other)
	{
		if (!alreadyTriggered && other.gameObject.CompareTag("Player"))
		{
			OpenWorldManager.Instance.PlayMonologue(data);
			alreadyTriggered = true;
			Invoke("ResetTrigger", 1);
		}
	}
	private void ResetTrigger()
	{
		alreadyTriggered = false;
	}
}
