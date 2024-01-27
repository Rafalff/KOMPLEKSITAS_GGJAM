using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalingBehaController : MonoBehaviour
{
    [SerializeField] private Npc banci;
	[SerializeField] private BangBlok banglok;
	[SerializeField] private GameObject[] HideObject;
	[SerializeField] private GameObject[] ShowObject;
	[SerializeField] private bool isActive;
	[SerializeField] private InventoryData inventoryData;
	[SerializeField] private DialogueScriptable dialogueData;
	[SerializeField] private List<Transform> waypoints;
	[SerializeField] private GameObject malingBehaKetangkepTrigger;

	private void Start()
	{
		banci.OnCleared += Cleared;
		banci.OnTrigger += Triggerred;
		for (int i = 0; i < ShowObject.Length; i++)
		{
			ShowObject[i].SetActive(false);
		} 
	}
	private void OnDestroy()
	{
		banci.OnCleared -= Cleared;
		banci.OnTrigger -= Triggerred;
	}
	private void Cleared()
	{
		isActive = false;
		for (int i = 0; i < HideObject.Length; i++)
		{
			HideObject[i].SetActive(true);
		}
		for (int i = 0; i < ShowObject.Length; i++)
		{
			ShowObject[i].SetActive(false);
		}
		GlobalGameManager.Instance.AddInventory(inventoryData);
		GlobalGameManager.Instance.ClearRokok();
	}
	private void Triggerred()
	{
		if (!isActive)
		{
			Debug.Log("Trigger Maling Beha");
			OpenWorldManager.Instance.GetDialogue().afterDialogueCompleted += PlayMalingMinigame;
			OpenWorldManager.Instance.PlayDialogue(dialogueData);
			isActive = true;
		}
	}
	private void PlayMalingMinigame()
	{
		Debug.Log("Play Maling Minigame");
		banglok.AddWaypoints(waypoints);
		for (int i = 0; i < HideObject.Length; i++)
		{
			HideObject[i].SetActive(false);
		}
		for (int i = 0; i < ShowObject.Length; i++)
		{
			ShowObject[i].SetActive(true);
		}
	}
	public void MalingBehaKetangkep()
	{ 
		
	}
}
