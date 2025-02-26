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
    [SerializeField] private InventoryData inventoryData;
    [SerializeField] private ShopData shopData;

    [SerializeField] private Transform content;

    private Dictionary<string, bool> purchasedItems = new Dictionary<string, bool>();
    private GoldShow goldShow;
    private DiaShow diaShow;

    void Awake()
    {
        if (instance == null)
            instance = this;

        goldShow = uIController.GetComponent<GoldShow>();
        diaShow = uIController.GetComponent<DiaShow>();
    }

    void Start()
    {
        UpdateItemList(shopData.items);
    }

    public void UpdateItemList(List<GameObject> items)
    {
        if (items == null)
            return;

        int idx = 0;
        foreach (GameObject item in items)
        {
            GameObject newItem = Instantiate(item, content);
            newItem.GetComponent<Item>().Init(idx);

            idx++;
        }
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
            // shopData.items.Remove(item.gameObject);
            // Destroy(item.gameObject);
            Item temp = shopData.items[item.itemIdx].GetComponent<Item>();
            inventoryData.listItem.Add(temp);
        }
    }
}
