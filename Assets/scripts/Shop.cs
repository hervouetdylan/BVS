using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public Item[] itemsSales;
    
    public void Start()
    {
        //FindObjectOfType<ShopManager>().OpenShop(itemsSales);
    }
    public void OpenShop()
    {
        FindObjectOfType<ShopManager>().OpenShop(itemsSales);
    }
    
}
