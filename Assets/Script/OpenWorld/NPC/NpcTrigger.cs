using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTrigger : MonoBehaviour
{
	[SerializeField] private Npc npc;
	[SerializeField] private bool autoTrigger; 
	private void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (!autoTrigger)
			{
				npc.CanInteract();
			}
			else {
				if (!npc.alreadyInteracted)
					npc.Trigger();
			}
			//GameManager.Instance.GetPlayerData().TouchNpc(npc);
		}
	}
	private void OnTriggerExit(Collider collision)
	{
		if (collision.CompareTag("Player"))
		{
			npc.CantInteract();
			//GameManager.Instance.GetPlayerData().UnTouchNpc();
		}
	}
}
