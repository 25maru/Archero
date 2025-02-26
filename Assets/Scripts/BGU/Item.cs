using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ItemType { Weapon, Armor, Head, Shoes, Ring, Necklace, End }

public class Item : MonoBehaviour
{
    [SerializeField] Button btnPanel;

    Sprite spriteItem;
    public Sprite SpriteItem
    {
        get { return spriteItem; }
    }

    public int itemIdx;
    public string Name;
    public float Attack;
    public float Health;
    public int Cost;
    public ItemType Type;

    private void Awake()
    {
        btnPanel = GetComponent<Button>();

        if (SceneManager.GetActiveScene().name == "InventoryScene")
        {
            btnPanel.onClick.AddListener(ShowPanel);
        }
        else if (SceneManager.GetActiveScene().name == "ShopScene")
        {
            btnPanel.onClick.AddListener(() => ShopManager.Instance.BuyItem(this));
        }
    }

    private void ShowPanel()
    {
        InventoryManager.Instance.SetActive.TogglePanel(gameObject);
    }

    public void Init(int itemIdx)
    {
        this.itemIdx = itemIdx;
    }

    public Sprite GetItemSprite()
    {
        return GetComponentsInChildren<Image>()[1].sprite;
    }
}
