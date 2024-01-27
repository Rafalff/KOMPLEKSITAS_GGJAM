using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Npc : MonoBehaviour
{
	[SerializeField] private NpcData data;
	[SerializeField] private bool canInteract;
	[SerializeField] private GameObject interactObject;
	public bool alreadyInteracted;

	public event Action OnTrigger;

	public event Action OnCleared;

	public virtual void CanInteract()
	{
		canInteract = true;
		interactObject.SetActive(true);
	}
	public virtual void CantInteract()
	{
		canInteract = false;
		interactObject.SetActive(false);
	}
	public virtual void Interact()
	{
		if (alreadyInteracted) return;
			alreadyInteracted = true;
	}
	public void Trigger()
	{
		OnTrigger?.Invoke();
		alreadyInteracted = true;
	}
	public void Cleared()
	{
		OnCleared?.Invoke();
		alreadyInteracted = true;
	}
}
