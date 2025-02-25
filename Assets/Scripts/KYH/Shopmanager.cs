using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int playerGold = 1000; // �÷��̾��� �ʱ� ���
    public Text goldText; // ��� UI �ؽ�Ʈ

    public List<ShopItem> items; // ���� ������ ���
    public GameObject itemPrefab; // ������ ���� ������
    public Transform content; // Scroll View�� Content

    private Dictionary<string, bool> purchasedItems = new Dictionary<string, bool>(); // ������ ������ ����

    void Start()
    {
        UpdateGoldUI();
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

            // �������� �̹� ���ŵǾ����� ��ư ��Ȱ��ȭ
            if (purchasedItems.ContainsKey(item.itemName) && purchasedItems[item.itemName])
            {
                buyButton.interactable = false;
                buyButton.GetComponentInChildren<Text>().text = "���� �Ϸ�";
            }
            else
            {
                buyButton.onClick.AddListener(() => BuyItem(item, buyButton));
            }
        }
    }

    void BuyItem(ShopItem item, Button buyButton)
    {
        if (playerGold >= item.price)
        {
            playerGold -= item.price;
            purchasedItems[item.itemName] = true; // ���� ���� ����
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = "���� �Ϸ�";
            UpdateGoldUI();
            Debug.Log($"{item.itemName} ���� �Ϸ�! ���� ���: {playerGold}");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
        }
    }

    void UpdateGoldUI()
    {
        goldText.text = $"��� {playerGold}";
    }
}



[System.Serializable]
public class ShopItem
{
    public string itemName;
    public Sprite itemIcon;
    public int price;
}

