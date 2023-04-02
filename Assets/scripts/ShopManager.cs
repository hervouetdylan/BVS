using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    private InventoryScript inventaire;
    public Item[] Items;
    void Start()
    {
        inventaire = InventoryScript.instance;

    }


    public void BuyItem(Item item)
    {
        if (inventaire.items.Count == inventaire.size)
        {
            inventaire.Add(item);
        }
    }

    public void OpenShop(Item[] items)
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
        canvasGroup.interactable = !canvasGroup.interactable;


        Items = items;
        Image[] images = GetComponentsInChildren<Image>();
        int j = 0;
        for (int i = 0;i<images.Length;i++)
        {
            Debug.Log(images[i].name);
            if (images[i].name.Contains("Item"))
            {
                images[i].sprite = items[j].icon;
                j++;
            }
        }
    }

  
}
