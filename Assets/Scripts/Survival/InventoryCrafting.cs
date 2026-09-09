using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory { Resource, Weapon, Building, Consumable, Cosmetic }

[CreateAssetMenu(fileName = "New Item", menuName = "LIOS/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemID;
    public string itemName;
    public ItemCategory category;
    public Sprite icon;
    public int maxStackSize = 1000;
}

public class InventoryCrafting : MonoBehaviour
{
    public Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();
    public int activeHotbarSlot = 0;
    public int currentWorkbenchTier = 0;

    public bool AddItem(ItemData item, int amount)
    {
        if (items.ContainsKey(item)) items[item] += amount;
        else items.Add(item, amount);
        return true;
    }
}
