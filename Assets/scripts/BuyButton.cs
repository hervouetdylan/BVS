using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyButton : MonoBehaviour
{
    private InventoryScript inventaire;
    void Start()
    {
        inventaire = InventoryScript.instance;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {

        int nb = int.Parse(GetComponent<Transform>().name[17].ToString());
        Debug.Log(nb);

        Item[] items = GetComponentInParent<ShopManager>().Items;
        foreach(Item item in items) Debug.Log(item);
        if (inventaire.items.Count < inventaire.size)
        {
            inventaire.Add(items[nb]);
        }
    }

}
