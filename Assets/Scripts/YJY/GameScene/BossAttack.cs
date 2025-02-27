using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] List<Rect> spawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);

    public Animator BossAnimator;
    public BaseStat BossStat;

    float Attackturn = 10f;
    int AttackNum = 5;

    private void Update()
    {
        Attack();
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
