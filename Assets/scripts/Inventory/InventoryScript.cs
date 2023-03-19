using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instance as once are use");
        }
        else
        {
            instance = this;
        }

    }
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    public List<Item> items = new List<Item>();

    public int size = 16;

    // Start is called before the first frame update
    public void Add(Item item)
    {
        if (items.Count <=size)
        {
            items.Add(item);
            if (OnItemChangedCallBack != null) 
                OnItemChangedCallBack.Invoke();
        }
        else
        {
            Debug.Log("Trop d'item dans l'inventaire");
        }
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallBack != null)
            OnItemChangedCallBack.Invoke();
    }
}
