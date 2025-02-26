using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textGold;
    [SerializeField] TextMeshProUGUI textDiamond;
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] TextMeshProUGUI textHealth;
    [SerializeField] TextMeshProUGUI textAttack;
    [SerializeField] GridLayoutGroup gridItem;
    [SerializeField] Image[] equipSlot;

    // PlayerStat 참조
    [SerializeField] PlayerData playerData;

    InventoryData invenData;
    GridLayoutGroup gridLayout;

    private void Start()
    {

        invenData = InventoryManager.Instance.InventoryHandler.Data;

        gridLayout = GetComponentInChildren<GridLayoutGroup>();

        if (playerData != null)
        {
            // PlayerStat의 값을 가져와 UI 업데이트
            UpdateUIFromPlayerStat();
        }

        UpdateItemList(invenData.listItem);

        UpdateEquipSlot(ItemType.Weapon, invenData.equipment_Weapon?.GetItemSprite());
        UpdateEquipSlot(ItemType.Armor, invenData.equipment_Armor?.GetItemSprite());
        UpdateEquipSlot(ItemType.Head, invenData.equipment_Head?.GetItemSprite());
        UpdateEquipSlot(ItemType.Shoes, invenData.equipment_Shoes?.GetItemSprite());
        UpdateEquipSlot(ItemType.Ring, invenData.equipment_Ring?.GetItemSprite());
        UpdateEquipSlot(ItemType.Necklace, invenData.equipment_Necklace?.GetItemSprite());
    }

    public void UpdateUIFromPlayerStat()
    {
        textGold.text = playerData.Gold.ToString();
        textDiamond.text = playerData.Diamond.ToString();
        textName.text = playerData.Name;
        textHealth.text = playerData.MaxHP.ToString();
        textAttack.text = playerData.AttackDamage.ToString();
    }

    #region Update UIText
    public void UpdateGold(float gold)
    {
        textGold.text = gold.ToString();
    }

    public void UpdateDiamond(float diamond)
    {
        textDiamond.text = diamond.ToString();
    }

    public void UpdateName(string name)
    {
        textName.text = name;
    }

    public void UpdateHealth(float maxHealth)
    {
        textHealth.text = maxHealth.ToString();
    }

    public void UpdateAttack(float attack)
    {
        textAttack.text = attack.ToString();
    }
    #endregion

    public void UpdateItemList(List<Item> items)
    {
        if (items == null)
            return;

        int idx = 0;
       foreach (Item item in items)
        {
            Item newItem = Instantiate(item, gridLayout.transform);
            newItem.Init(idx);

            idx++;
        }
    }

    public void UpdateEquipSlot(ItemType type, Sprite sprite)
    {
        equipSlot[(int)type].sprite = sprite;
    }
}
