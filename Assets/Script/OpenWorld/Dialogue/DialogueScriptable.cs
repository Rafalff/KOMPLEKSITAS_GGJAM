using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/DialogueData", order = 5)]
public class DialogueScriptable : ScriptableObject
{
    public List<Dialogue> dialogueList = new List<Dialogue>();
    // data = Resources.Load<DialogueScriptable>("Scripts/Scriptable Objects/Dialogue/" + type.ToString());

}
