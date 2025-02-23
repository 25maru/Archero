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

    Image[] listItem;

    private void Start()
    {
        // ���ư��� ��ư Ŭ�� �̺�Ʈ ����
        btnReturn.onClick.AddListener(OnClickReturn);

        // ItemView �̹����� ����
        listItem = gridItem.GetComponentsInChildren<Image>();
    }

    private void OnClickReturn()
    {
        // �ڷ� ����
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
            listItem[i].sprite = items[i].ItemSprite.sprite;
        }
    }
}

// �ӽ� ������ Ŭ����
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