using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrunkController : MonoBehaviour
{
    [SerializeField] private GameObject npcTrigger;
    [SerializeField] private BangBlok bangBlok;
	[SerializeField] private DialogueScriptable dialogueData;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private Transform tempatBanglokModar;
	
	private void Start()
	{
		npcTrigger.SetActive(false);
		bangBlok.OnTrigger += StartDialogue;
		
	}
	public void StartDialogue()
	{
		Debug.Log("StartDialogue");
		OpenWorldManager.Instance.GetDialogue().afterDialogueCompleted += MakePlayerDrunk;
		OpenWorldManager.Instance.PlayDialogue(dialogueData);
	}
	public void MakePlayerDrunk()
	{
		playerMovement.MakePlayerDrunk(false);
		playerMovement.SoberTimer();
	}
	public void SetelahDiterimaSayur()
	{
		bangBlok.transform.position = tempatBanglokModar.transform.position;
	
		npcTrigger.SetActive(false);
		bangBlok.Modar();
	}
	public void AfterLari()
	{
		bangBlok.transform.position = tempatBanglokModar.transform.position;
	}
	public void SebelumDiterimaSayur()
	{
		npcTrigger.SetActive(true);
	}
	public void MakePlayerSober()
	{
		playerMovement.MakePlayerDrunk(true);
	}
	public void ActivateTrigger()
    {
		npcTrigger.SetActive(true);
		AfterLari();
	}

}
