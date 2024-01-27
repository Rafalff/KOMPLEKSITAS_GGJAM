using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LemparinKucingController : MonoBehaviour
{
	[SerializeField] private GameObject npcTrigger;
	[SerializeField] private Nenek nenek;
	[SerializeField] private DialogueScriptable dialogueData;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private Transform tempatBanglokModar;

	private void Start()
	{
		npcTrigger.SetActive(false);
		nenek.OnTrigger += StartDialogue;
	}
	public void StartDialogue()
	{
		Debug.Log("StartDialogue");
		OpenWorldManager.Instance.GetDialogue().afterDialogueCompleted += GoToLemparKucing;
		OpenWorldManager.Instance.PlayDialogue(dialogueData);
	}
	private void GoToLemparKucing()
	{
		SceneManager.LoadScene("MinigameKucing");
	}
	public void SetelahSelesaiLemparKucing()
	{
		npcTrigger.SetActive(false);
		Debug.Log("SelesaiLemparKucing");
	}
	public void SebelumSelesaiLemparKucing()
	{
		Debug.Log("SebelumSelesaiLemparKucing");
	}
	
}
