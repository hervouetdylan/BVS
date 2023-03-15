using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotScript : MonoBehaviour
{
    public GameObject images;
    public Image icon = null;
    Item item;
    public void Awake()
    {
        icon = images.GetComponent<Image>();
    }
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        icon.color = new Color(1f, 1f, 1f,1f);
    }

    public void ClearSlot()
    {
        if (item != null)
        {
            item = null;

            icon.sprite = null;
            icon.enabled = false;
            icon.color = new Color(1f, 1f, 1f, 0f);
        }
       

    }
}
