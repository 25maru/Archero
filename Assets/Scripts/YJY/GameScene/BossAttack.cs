using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] List<Rect> spawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);

    public Animator BossAnimator;
    public BaseStat BossStat;

    float Attackturn = 10f;
    float time = 0;
    int AttackNum = 5;
    bool isChange = false;

    public List<GameObject> NormalAttack;
    public List<GameObject> ChangeAttack;

    private void Start()
    {
        InvokeRepeating(nameof(Attack), 0, Attackturn);
    }

    private void Update()
    {
        if(BossStat.dead == true && isChange == false)
        {
            isChange = true;
            BossAnimator.SetBool("IsChange", true);
            CancelInvoke(nameof(Attack));
            Attackturn = 6f;
            int AttackNum = 7;
            InvokeRepeating(nameof(Attack), 0, Attackturn);
        }
    }

    void Attack()
    {
        BossAnimator.SetTrigger("AttackTrigger");
    }


    private void OnDrawGizmosSelected()
    {
        if (spawnAreas == null) return;

        Gizmos.color = gizmoColor;
        foreach (var area in spawnAreas)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);

            Gizmos.DrawCube(center, size);
        }
    }
}
