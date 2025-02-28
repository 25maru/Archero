using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] List<GameObject> listAbility;
    [SerializeField] HorizontalLayoutGroup layoutGroup;
    
    List<GameObject> randomAbility = new List<GameObject>();
    
    // �������� �ɷ�ġ ��� ������ 3�� ����
    private void SetRandomAbility()
    {
        List<int> rand = new List<int>();

        while (true)
        {
            int temp = Random.Range(0, listAbility.Count - 1);

            if (rand.Contains(temp))
                continue;

            rand.Add(temp);

            if (rand.Count == 3) break;
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

        Time.timeScale = 0f;

        SetRandomAbility();
    }

    public void Hide()
    {
        // �������� ���� �ɷ�ġ����Ʈ ����
        foreach (GameObject ability in randomAbility)
        {
            Destroy(ability);
        }
        randomAbility.Clear();

        gameObject.SetActive(false);


        Time.timeScale = 1f;
    }
}
