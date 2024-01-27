using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LemparinKucingController : MonoBehaviour
{
	[SerializeField] private GameObject npcTrigger;
	[SerializeField] private GameObject npcTrigger2;

	[SerializeField] private Nenek nenek;
	[SerializeField] private DialogueScriptable dialogueData;
	[SerializeField] private DialogueScriptable dialogueAfterData;
	[SerializeField] private MonologueData bolaVoli;
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
		GlobalGameManager.Instance.lastOpenWorldPosition = playerMovement.transform.position;
		SoundManager.Instance.PlayMusic(SoundName.KucingMusic);
		SceneManager.LoadScene("MinigameKucing");
	}
	public void SetelahSelesaiLemparKucing()
	{
		npcTrigger.SetActive(false);
		npcTrigger2.SetActive(false);
		Debug.Log("SelesaiLemparKucing");
		OpenWorldManager.Instance.GetDialogue().afterDialogueCompleted += BerikanHadiah;
		OpenWorldManager.Instance.PlayDialogue(dialogueAfterData);
	}
	public void BerikanHadiah()
	{
		GlobalGameManager.Instance.ClearMicin();
		GlobalGameManager.Instance.GetKreestal();
		StartCoroutine(BolaVoliDelay());
	}
	private IEnumerator BolaVoliDelay()
	{
		yield return new WaitForSeconds(3f);
		OpenWorldManager.Instance.PlayMonologue(bolaVoli);
	}
	public void SebelumSelesaiLemparKucing()
	{
		Debug.Log("SebelumSelesaiLemparKucing");
	}
	
}
