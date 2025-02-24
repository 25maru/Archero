using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> items; // 상점 아이템 목록
    public GameObject itemPrefab; // 아이템 슬롯 프리팹
    public Transform content; // Scroll View의 Content

    void Start()
    {
        PopulateShop();
    }

    void PopulateShop()
    {
        foreach (ShopItem item in items)
        {
            GameObject newItem = Instantiate(itemPrefab, content);
            newItem.transform.Find("ItemName").GetComponent<Text>().text = item.itemName;
            newItem.transform.Find("Price").GetComponent<Text>().text = item.price.ToString();
            newItem.transform.Find("Icon").GetComponent<Image>().sprite = item.itemIcon;

            Button buyButton = newItem.transform.Find("BuyButton").GetComponent<Button>();
            buyButton.onClick.AddListener(() => BuyItem(item));
        }
    }

    void BuyItem(ShopItem item)
    {
        Debug.Log($"{item.itemName} 구매 완료! 가격: {item.price}");
    }
}



[System.Serializable]
public class ShopItem
{
    public string itemName;
    public Sprite itemIcon;
    public int price;
}

