using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance;
    SelectState state;
    bool isChange = false;
    bool isFirst = true;

    public Animator ChangeMapEffect;

    public GameObject TutorialMap;
    public GameObject NormalMap;

    public GameObject CurrentMap;
    [SerializeField]GameObject child;

    public enum SelectState
    {
        Tutorial,
        Normal
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        state = SelectState.Normal;
        ChangeState(SelectState.Tutorial);
    }

    public void ChangeState(SelectState selectState) //��ư�� ���� �� ���� ��ȯ
    {
        if (state == selectState) return; //���� ���� ������ ����
        if (isChange) return; //�ٲ�� ������ ����

        state = selectState;
        isChange = true;

        switch (state)
        {
            case SelectState.Tutorial:
                ChangeMap(TutorialMap);
                break;
            case SelectState.Normal:
                ChangeMap(NormalMap);
                break;
        }
    }
    void ChangeMap(GameObject Map)
    {
        CurrentMap = Map;

        if (isFirst) //ó�� ������ ��
        {
            isFirst = false;
            InvokeChangeMap();
        }
        else
        {
            ChangeMapEffect.SetTrigger("ChangeScene");
            Invoke("InvokeChangeMap", 0.7f);
        }
    }
    void InvokeChangeMap()
    {
        DestroyAllCgild();
        Instantiate(CurrentMap, this.transform);
        isChange = false;
    }
    void DestroyAllCgild()
    {
        foreach(Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
