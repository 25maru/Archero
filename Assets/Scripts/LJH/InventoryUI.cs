using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textGold;
    [SerializeField] TextMeshProUGUI textDiamond;
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] TextMeshProUGUI textHealth;
    [SerializeField] TextMeshProUGUI textAttack;
    [SerializeField] Button btnReturn;
    [SerializeField] GridLayoutGroup gridItem;
    
    // PlayerStat 참조
    [SerializeField] PlayerData playerData;

    Image[] listItem;

    private void Start()
    {
        // 돌아가기 버튼 클릭 이벤트 연결
        btnReturn.onClick.AddListener(OnClickReturn);

        // ItemView 이미지들 참조
        listItem = gridItem.GetComponentsInChildren<Image>();

        if (playerData != null)
        {
            // PlayerStat의 값을 가져와 UI 업데이트
            UpdateUIFromPlayerStat();
        }
    }

    public void UpdateUIFromPlayerStat()
    {
        textGold.text = playerData.Gold.ToString();
        textDiamond.text = playerData.Diamond.ToString();
        textName.text = playerData.Name;
        textHealth.text = playerData.MaxHP.ToString();
        textAttack.text = playerData.AttackDamage.ToString();
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
        for(int i = 0; i < listItem.Length; i++)
        {
            if (i > items.Count)
                listItem[i] = null;

            listItem[i].sprite = items[i].ItemSprite.sprite;
        }
    }
}

// 임시 아이템 클래스
public class Item : MonoBehaviour
{
    SpriteRenderer itemSprite;
    public SpriteRenderer ItemSprite { get; private set; }

    float attack;
    public float Attack { get; private set; }

    float health;
    public float Health { get; private set; }

    ItemType type;
    public ItemType Type { get; private set; }
}