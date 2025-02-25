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

    public void ChangeState(SelectState selectState) //버튼을 누를 시 상태 변환
    {
        if (state == selectState) return; //같은 것을 누르면 거절
        if (isChange) return; //바뀌고 있으면 거절

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

        if (isFirst) //처음 실행일 시
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
