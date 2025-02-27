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
        // �������� ���� �ɷ�ġ����Ʈ ����
        foreach (GameObject ability in randomAbility)
        {
            Destroy(ability);
        }
        randomAbility.Clear();

        gameObject.SetActive(false);
    }
}
