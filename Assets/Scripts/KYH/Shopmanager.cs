using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> items; // ���� ������ ���
    public GameObject itemPrefab; // ������ ���� ������
    public Transform content; // Scroll View�� Content

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
        Debug.Log($"{item.itemName} ���� �Ϸ�! ����: {item.price}");
    }
}



[System.Serializable]
public class ShopItem
{
    public string itemName;
    public Sprite itemIcon;
    public int price;
}

