using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	[SerializeField] private Canvas canvas;
	public GameObject DialogueObject;
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public Image charImage;
	public Button nextButton;
	public List<Dialogue> dialogueList = new List<Dialogue>();

	[SerializeField] private int index;
	[SerializeField] private AudioSource soundSource;
	private bool textAnimating;
	private float curAnimateCd = 0;
	private float animateCd = 0.025f;

	public event Action afterDialogueCompleted;
	public void Show()
	{
		canvas.enabled = true;
	}
	public void Hide()
	{
		canvas.enabled = false;
	}
	void Start()
	{
		nextButton.onClick.RemoveAllListeners();
		nextButton.onClick.AddListener(NextDialogue);
		index = 0;
	}
	public void HideNextButton()
	{
		nextButton.gameObject.SetActive(false);
	}
	public void NewDialogue(DialogueScriptable data)
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Show();
		OpenWorldManager.Instance.Pause();
		dialogueList = data.dialogueList;
		index = 0;
		PopDialogue(dialogueList[index]);
	}
	public void NextDialogue()
	{
		if (textAnimating) return;
		if (index < dialogueList.Count - 1)
		{
			index++;
			PopDialogue(dialogueList[index]);
		}
		else
		{
			OpenWorldManager.Instance.Continue();
			HideDialogue();
			afterDialogueCompleted?.Invoke();
			afterDialogueCompleted = null;
			soundSource.Stop();
		}
	}
	string totalDialogueText = "";
	char[] dialogueTextArray;
	int animateIndex = 0;
	public void PopDialogue(Dialogue dialogue)
	{
		soundSource.clip = dialogue.voice;
		soundSource.Play();
		DialogueObject.SetActive(true);
		charImage.sprite = dialogue.imageSprite;
		nameText.text = dialogue.name;
		totalDialogueText = dialogue.text;
		dialogueTextArray = totalDialogueText.ToCharArray();

		dialogueText.text = "";
		textAnimating = true;
		curAnimateCd = animateCd;
	}
	private void Update()
	{
		if (textAnimating)
		{
			if (curAnimateCd > 0)
			{
				curAnimateCd -= Time.deltaTime;
			}
			else
			{
				if (animateIndex < dialogueTextArray.Length)
				{
					dialogueText.text += dialogueTextArray[animateIndex];
					animateIndex++;
					curAnimateCd = animateCd;
				}
				else
				{
					textAnimating = false;
					animateIndex = 0;
				}
			}
		}
	}
	public void HideDialogue()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Hide();
		DialogueObject.SetActive(false);
	}
}
