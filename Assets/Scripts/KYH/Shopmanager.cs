using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private static ShopManager instance;
    public static ShopManager Instance => instance;

    [SerializeField] private MenuUIController uIController;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ShopData shopData;

    [SerializeField] private Transform content;

    private Dictionary<string, bool> purchasedItems = new Dictionary<string, bool>();
    private GoldShow goldShow;
    private DiaShow diaShow;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        PopulateShop();
    }

    void PopulateShop()
    {
        foreach (GameObject item in shopData.items)
        {
            GameObject newItem = Instantiate(item, content);
        }
    }

    public void BuyItem(Item item)
    {
        if (goldShow.Use(item.Cost))
        {
            shopData.items.Remove(item.gameObject);
            Destroy(item.gameObject);
            InventoryManager.Instance.InventoryHandler.Data.listItem.Add(item);
        }
    }
}
