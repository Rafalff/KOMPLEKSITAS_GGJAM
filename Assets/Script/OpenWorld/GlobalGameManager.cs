using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
	public static GlobalGameManager Instance;
	[SerializeField] private List<InventoryData> inventory;
	[SerializeField] public bool clearMicin { get; private set; }
	[SerializeField] public bool clearRokok { get; private set; }
	[SerializeField] public bool clearSayur { get; private set; }
	private void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(this.gameObject);
		}
		else {
			if (Instance != this)
			{
				Destroy(gameObject);
			}
		}
	}
	public void AddInventory(InventoryData data)
	{
		inventory.Add(data);
	}
	public void ClearMicin()
	{
		clearMicin = true;
	}
	public void ClearRokok()
	{
		clearRokok = true;
	}
	public void ClearSayur()
	{
		clearSayur = true;
	}
	public bool CheckFullItem()
	{
		bool haveRokok = false;
		bool haveMicin = false;
		bool haveDaun = false;
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[i].Name == "Daun")
			{
				haveDaun = true;
			} else if (inventory[i].Name =="Micin")
			{
				haveMicin = true;
			}
			else if (inventory[i].Name == "Rokok")
			{
				haveDaun = true;
			}
		}
		if (haveRokok && haveMicin && haveDaun)
		{
			return true;
		}
		else {
			return false;
		}
	}
}
