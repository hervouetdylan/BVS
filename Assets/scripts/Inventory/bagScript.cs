using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagScript : MonoBehaviour
{
    InventoryScript inventoryScript;

    slotScript[] slots;

    private void Start()
    {
        inventoryScript = InventoryScript.instance;
        inventoryScript.OnItemChangedCallBack += UpdateUI;

        slots = GetComponentsInChildren<slotScript>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        
        for (int i =0;i<slots.Length;i++)
        {
            
            if (i<inventoryScript.items.Count)
            {
                slots[i].AddItem(inventoryScript.items[i]);
                
            }else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
