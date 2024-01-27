using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenWorldManager : MonoBehaviour
{
    public static OpenWorldManager Instance;

    [SerializeField] private MalingBehaController malingBehaController;
    [SerializeField] private PlayerDrunkController playerDrunkController;
    [SerializeField] private InventoryController inventoryController;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ThirdPersonCamera camera;
    [SerializeField] private MonologueManager monologueManager;
    [SerializeField] private DialogueManager dialogueManager;


	private void Awake()
	{
        Instance = this;
	}
	private void Start()
	{
        OpenWorldManager.Instance.ShowInventory(GlobalGameManager.Instance.GetInventory());
    }
    public void ShowInventory(List<InventoryData> data)
    {
        inventoryController.Show(data);
    }
    public void PlayMonologue(MonologueData data)
    {
        monologueManager.StartMonologue(data);
    }
    public void PlayDialogue(DialogueScriptable data)
    {
        dialogueManager.NewDialogue(data);
    }
    public void MalingBehaKetangkep()
    {
        malingBehaController.MalingBehaKetangkep();
    }
    public void SetelahDiterimaSayur()
    {
        playerDrunkController.SetelahDiterimaSayur() ;
    }
    public void SebelumDiterimaSayur()
    {
        playerDrunkController.SebelumDiterimaSayur();
    }
    public void MalingBehaBelomKetangkep()
    {
        malingBehaController.MalingBehaBelomKetangkep();
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
