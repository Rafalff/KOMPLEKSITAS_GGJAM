using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InventoryData", order = 1)]

public class InventoryData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite sprite;
}
