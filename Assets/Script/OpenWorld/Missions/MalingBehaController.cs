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
	[SerializeField] private DialogueScriptable afterBalikinDialogueData;
	[SerializeField] private List<Transform> waypoints;
	[SerializeField] private GameObject malingBehaKetangkepTrigger;
	[SerializeField] private Transform tempatBanciKedua;

	private void Start()
	{
		
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
	private void AfterKetangkepTriggerred()
	{
		if (!isActive)
		{
			Debug.Log("After Ketangkep Triggerred");
			OpenWorldManager.Instance.GetDialogue().afterDialogueCompleted += AfterBalikinBeha;
			OpenWorldManager.Instance.PlayDialogue(afterBalikinDialogueData);
			isActive = true;
		}
	}
	private void AfterBalikinBeha()
	{
		GlobalGameManager.Instance.ClearRokok();
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
	public void MalingBehaBelomKetangkep()
	{
		banci.OnCleared += Cleared;
		banci.OnTrigger += Triggerred;
		malingBehaKetangkepTrigger.gameObject.SetActive(false);
		Debug.Log("MalingBehaBelomKetangkep");

	}
	public void MalingBehaKetangkep()
	{
		banci.OnCleared += AfterBalikinBeha;
		banci.OnTrigger += AfterKetangkepTriggerred;
		malingBehaKetangkepTrigger.gameObject.SetActive(true);
		banci.transform.position = tempatBanciKedua.position;
		Debug.Log("MalingBehaKetangkep");
	}
}
