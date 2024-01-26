using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MonologueData", order = 1)]
public class MonologueData : ScriptableObject
{
    public Color color;
    public string[] textList; 
    public AudioClip[] voiceList;
    public int[] delay;
}
