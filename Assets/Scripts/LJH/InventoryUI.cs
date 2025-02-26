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
    
    // PlayerStat 참조
    [SerializeField] PlayerData playerData;

    InventoryData invenData;
    GridLayoutGroup gridLayout;

    private void Awake()
    {
        // 돌아가기 버튼 클릭 이벤트 연결
        btnReturn.onClick.AddListener(OnClickReturn);

        invenData = GetComponent<InventoryHandler>().Data;

        gridLayout = GetComponentInChildren<GridLayoutGroup>();

        if (playerData != null)
        {
            // PlayerStat의 값을 가져와 UI 업데이트
            UpdateUIFromPlayerStat();
        }

        UpdateItemList(invenData.listItem);
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
        if (items == null)
            return;

       foreach (Item item in items)
        {
            Instantiate(item, gridLayout.transform);
        }
    }
}
