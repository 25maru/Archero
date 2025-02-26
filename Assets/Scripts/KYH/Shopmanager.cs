using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private MenuUIController uIController;
    [SerializeField] private PlayerData playerData;

    [SerializeField] private List<GameObject> items;
    [SerializeField] private Transform content;

    private Dictionary<string, bool> purchasedItems = new Dictionary<string, bool>();
    private GoldShow goldShow;
    private DiaShow diaShow;

    void Start()
    {
        PopulateShop();
    }

    void PopulateShop()
    {
        foreach (GameObject item in items)
        {
            GameObject newItem = Instantiate(item, content);
            Button buyButton = newItem.transform.Find("BuyButton").GetComponent<Button>();
        }
    }

    public void BuyItem(Item item)
    {
        if (goldShow.Use(item.Cost))
        {
            // 아이템 삭제 -> 인벤토리로 이동
        }
    }
}
