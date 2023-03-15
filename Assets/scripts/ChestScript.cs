using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    InventoryChest inventoryChest;

    slotScript[] slots;

    private void Start()
    {
        inventoryChest = InventoryChest.instance;
        inventoryChest.OnItemChangedCallBack += UpdateUI;

        slots = GetComponentsInChildren<slotScript>();
        UpdateUI();
    }

    public void UpdateUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {

            if (i < inventoryChest.items.Count)
            {
                slots[i].AddItem(inventoryChest.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
