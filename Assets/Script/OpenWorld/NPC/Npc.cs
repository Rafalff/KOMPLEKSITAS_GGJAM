using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
	[SerializeField] private NpcData data;
	[SerializeField] private bool canInteract;
	[SerializeField] private GameObject interactObject;
	[SerializeField] private bool alreadyInteracted;
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
}
