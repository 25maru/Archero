using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentScroll : MonoBehaviour
{
    public List<GameObject> Contents;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        if (Contents == null) return;

        foreach(GameObject i in Contents)
        {
            var index = Instantiate(i);
            index.transform.SetParent(this.transform);
            index.transform.position = new Vector3(index.transform.position.x, index.transform.position.y, -5); //��ġ�� 1�� ����� ����
            index.transform.localScale = new Vector3(1f, 1f, 1f); //scale�� 1�� ����� ����
        }
    }
}
