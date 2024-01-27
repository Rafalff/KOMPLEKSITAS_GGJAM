using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepCaller : MonoBehaviour
{
	[SerializeField] PlayerMovement player;

	public void FootStep()
	{
		Debug.Log("FootStep");
		player.StepSound();
	}
}
