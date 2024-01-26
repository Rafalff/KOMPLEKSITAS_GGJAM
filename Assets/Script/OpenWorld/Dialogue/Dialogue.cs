using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
	public string imageName;
	public string name;
	[TextArea]
	public string text;
	public Sprite imageSprite;
	public AudioClip voice;


}

