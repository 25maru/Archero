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
    [SerializeField] Button btnReturn;
    [SerializeField] GridLayoutGroup gridItem;
    [SerializeField] Image[] equipSlot;

    // PlayerStat 참조
    [SerializeField] PlayerData playerData;

    InventoryData invenData;
    GridLayoutGroup gridLayout;

    private void Start()
    {
        // 돌아가기 버튼 클릭 이벤트 연결
        btnReturn.onClick.AddListener(OnClickReturn);

        invenData = InventoryManager.Instance.InventoryHandler.Data;

        gridLayout = GetComponentInChildren<GridLayoutGroup>();

        if (playerData != null)
        {
            // PlayerStat의 값을 가져와 UI 업데이트
            UpdateUIFromPlayerStat();
        }

        // 인벤토리 아이템 리스트 업데이트
        UpdateItemList(invenData.listItem);

        // 장착 중인 아이템 업데이트
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
        textHealth.text = ((int)(playerData.MaxHP + InventoryManager.Instance.InventoryHandler.GetEquipAvility_Health())).ToString();
        textAttack.text = ((int)(playerData.AttackDamage + InventoryManager.Instance.InventoryHandler.GetEquipAvility_Attack())).ToString();
    }

    private void OnClickReturn()
    {
        // 뒤로 가기
        SceneManager.LoadScene("MainScene");
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
