using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrunkController : MonoBehaviour
{
    [SerializeField] private GameObject npcTrigger;
    [SerializeField] private Npc bangBlok;
	[SerializeField] private DialogueScriptable dialogueData;
	[SerializeField] private PlayerMovement playerMovement;
	
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
	public void MakePlayerSober()
	{
		playerMovement.MakePlayerDrunk(true);
	}
	public void ActivateTrigger()
    {
		npcTrigger.SetActive(true);
	}

}
