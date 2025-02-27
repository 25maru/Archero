using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] List<GameObject> listAbility;
    [SerializeField] HorizontalLayoutGroup layoutGroup;
    
    List<GameObject> randomAbility = new List<GameObject>();
    
    // 랜덤으로 능력치 상승 선택지 3개 선택
    private void SetRandomAbility()
    {
        int[] rand = new int[3];
        int idx = 0;

        while (true)
        {
            if (idx >= 3)
                break;

            rand[idx] = Random.Range(0, listAbility.Count - 1);

            if (idx != 0)
            {
                if (rand[idx - 1].Equals(rand[idx]))
                    continue;
            }

            idx++;
        }

        foreach (int i in rand)
        {
            GameObject newInstance = Instantiate(listAbility[i], layoutGroup.transform);
            randomAbility.Add(newInstance);

            newInstance.GetComponent<AbilityHandler>().Init(this);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);

        SetRandomAbility();
    }

    public void Hide()
    {
        // 랜덤으로 만든 능력치리스트 삭제
        foreach (GameObject ability in randomAbility)
        {
            Destroy(ability);
        }
        randomAbility.Clear();

        gameObject.SetActive(false);
    }
}
