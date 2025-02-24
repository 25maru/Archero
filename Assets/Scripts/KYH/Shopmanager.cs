using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int playerGold = 1000; // 플레이어의 초기 골드
    public Text goldText; // 골드 UI 텍스트

    public List<ShopItem> items; // 상점 아이템 목록
    public GameObject itemPrefab; // 아이템 슬롯 프리팹
    public Transform content; // Scroll View의 Content

    private Dictionary<string, bool> purchasedItems = new Dictionary<string, bool>(); // 구매한 아이템 저장

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

            // 아이템이 이미 구매되었으면 버튼 비활성화
            if (purchasedItems.ContainsKey(item.itemName) && purchasedItems[item.itemName])
            {
                buyButton.interactable = false;
                buyButton.GetComponentInChildren<Text>().text = "구매 완료";
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
            purchasedItems[item.itemName] = true; // 구매 상태 저장
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = "구매 완료";
            UpdateGoldUI();
            Debug.Log($"{item.itemName} 구매 완료! 남은 골드: {playerGold}");
        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }

    void UpdateGoldUI()
    {
        goldText.text = $"골드 {playerGold}";
    }
}



[System.Serializable]
public class ShopItem
{
    public string itemName;
    public Sprite itemIcon;
    public int price;
}

