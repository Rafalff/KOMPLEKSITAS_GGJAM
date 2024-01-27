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
	[SerializeField] public bool malingKetangkep { get; private set; }

	[SerializeField] public InventoryData dataMicin;
	[SerializeField] public InventoryData dataRokok;
	[SerializeField] public InventoryData dataSayur;
	[SerializeField] public InventoryData dataKreestal;

	public Vector3 lastOpenWorldPosition;
	private void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(this.gameObject);
			Instance = this;
		}
		else {
			if (Instance != this)
			{
				Destroy(gameObject);
			}
		}
	}
	private void Start()
	{
		
	}
	public void CheckOpenScene()
	{
		if (clearMicin)
		{

		}
		if (clearRokok)
		{

		}
		else
		{

		}
		if (clearSayur)
		{
			OpenWorldManager.Instance.SetelahDiterimaSayur();
		}
		else {
			OpenWorldManager.Instance.SebelumDiterimaSayur();
		}
		if (malingKetangkep)
		{
			OpenWorldManager.Instance.MalingBehaKetangkep();
		}
		else {
			OpenWorldManager.Instance.MalingBehaBelomKetangkep();
		}
		OpenWorldManager.Instance.ShowInventory(inventory);
	}
	public void AddInventory(InventoryData data)
	{
		inventory.Add(data);
		if (OpenWorldManager.Instance != null)
		{
			OpenWorldManager.Instance.ShowInventory(inventory);
		}
	}
	public List<InventoryData> GetInventory()
	{
		return inventory;
	}
	public void MalingKetangkep()
	{
		malingKetangkep = true;
	}
	public void ClearMicin()
	{
		clearMicin = true;
		AddInventory(dataMicin);
	}
	public void ClearRokok()
	{
		clearRokok = true;
		AddInventory(dataRokok);
	}
	public void ClearSayur()
	{
		clearSayur = true;
		AddInventory(dataSayur);
	}
	public void GetKreestal()
	{
		AddInventory(dataKreestal);
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
