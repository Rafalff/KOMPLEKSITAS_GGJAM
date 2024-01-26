using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTrigger : MonoBehaviour
{
	[SerializeField] private Npc npc;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			npc.CanInteract();
			GameManager.Instance.GetPlayerData().TouchNpc(npc);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			npc.CantInteract();
			GameManager.Instance.GetPlayerData().UnTouchNpc();
		}
	}
}
