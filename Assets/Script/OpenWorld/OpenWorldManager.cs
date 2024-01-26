using System;
using UnityEngine;

public class OpenWorldManager : MonoBehaviour
{
    public static OpenWorldManager Instance;

    [SerializeField] private MalingBehaController malingBehaController;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ThirdPersonCamera camera;
    [SerializeField] private MonologueManager monologueManager;
    [SerializeField] private DialogueManager dialogueManager;


	private void Awake()
	{
        Instance = this;
	}
    public void PlayMonologue(MonologueData data)
    {
        monologueManager.StartMonologue(data);
    }
    public void PlayDialogue(DialogueScriptable data)
    {
        dialogueManager.NewDialogue(data);
    }
    public DialogueManager GetDialogue()
    {
        return dialogueManager;
    }
    public void Pause()
    {
        player.Pause();
        camera.Pause();
    }
    public void Continue()
    {
        player.Continue();
        camera.Continue();
    }
    
}
