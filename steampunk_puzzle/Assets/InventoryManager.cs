using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlot;

    public void AddItem(string itemName, Sprite itemSprite)
    {
        Debug.Log("itemName = " + itemName + "itemSprite = " + itemSprite);
        for (int i = 0; i < inventorySlot.Length; i++)
        {
            if (inventorySlot[i].isFull == false)
            {
                inventorySlot[i].AddItem(itemName, itemSprite);
                return;
            }
        }

    }
}
