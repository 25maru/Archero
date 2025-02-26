using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 임시 아이템 클래스
public class Item : MonoBehaviour
{
    [SerializeField] Button btnPanel;

    Sprite spriteItem;
    public Sprite SpriteItem
    {
        get { return spriteItem; }
    }
    public string Name;
    public float Attack;
    public float Health;
    public int Cost;
    public ItemType Type;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "InventoryScene")
        {
            spriteItem = GetComponentsInChildren<Image>()[1].sprite;

            btnPanel.onClick.AddListener(ShowPanel);
        }
        else if (SceneManager.GetActiveScene().name == "ShopScene")
        {

        }
    }

    private void ShowPanel()
    {
        InventoryManager.Instance.SetActive.TogglePanel(this);
    }

    public void GetSprite()
    {
        spriteItem = GetComponentsInChildren<Image>()[1].sprite;
    }
}
