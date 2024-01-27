using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Transform inventoryParent;
    [SerializeField] private Image inventoryPrefab;

    public void Show(List<InventoryData> data)
    {
        foreach (Transform t in inventoryParent)
        {
            Destroy(t.gameObject);
        }
        for (int i = 0; i < data.Count;i++)
        {
            Image icon = Instantiate(inventoryPrefab, inventoryParent);
            icon.sprite = data[i].sprite;
        }
    }
}
