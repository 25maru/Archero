using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] List<Rect> spawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.3f);
    [SerializeField] Vector2 randomPosition = new Vector2(0, 0);

    public Animator BossAnimator;
    public BaseStat BossStat;

    float Attackturn = 5f;
    int AttackNum = 7;
    bool isChange = false;

    public List<GameObject> NormalAttack;
    public List<GameObject> ChangeAttack;

    List<GameObject> NowAttack = new List<GameObject>();

    public TutorialController tutorialController;

    private void Start()
    {
        foreach(GameObject attack in NormalAttack)
        {
            NowAttack.Add(attack);
        }
        InvokeRepeating(nameof(Attack), 2, Attackturn);
    }

    private void Update()
    {
        if(BossStat.IsDead() && isChange == false)//죽었으면서 변신 전이면
        {
            Debug.Log("BossDead");
            BossStat.dead = false;
            BossStat.Heal(BossStat.GetMaxHealth() * 2);

            BossAnimator.SetBool("IsChange", true);
            CancelInvoke(nameof(Attack));
            Invoke(nameof(ChangePattern),1f);
        }
        else if (BossStat.IsDead() && isChange == true) //2번째 죽으면
        {
            CancelInvoke(nameof(Attack));
            BossAnimator.SetBool("IsDead", true);
            tutorialController.OpenGate();
            Invoke(nameof(Destroy), 2.5f);
        }
    }

    void ChangePattern()
    {
        isChange = true;
        Attackturn = 3f;
        AttackNum = 10;
        foreach(GameObject attack in ChangeAttack)
        {
            NowAttack.Add(attack);
        }
        InvokeRepeating(nameof(Attack), 0, Attackturn);
    }

    void Attack()
    {
        BossAnimator.SetTrigger("AttackTrigger");
        GameObject thispattern = NowAttack[Random.Range(0, NowAttack.Count)]; //랜덤 공격을 받음

        for (int i =0; i< AttackNum; i++)
        {
            Vector2 position = GetRandomPosition(); //랜덤 좌표를 받음
            Instantiate(thispattern, position, Quaternion.identity);
        }
    }
    Vector2 GetRandomPosition()
    {
        if (spawnAreas.Count == 0)
        {
            Debug.LogWarning("Spawn Areas가 설정되지 않았습니다.");
            return new Vector2(0,0);
        }

        Rect randomArea = spawnAreas[Random.Range(0, spawnAreas.Count)];
        randomPosition = new Vector2(Random.Range(randomArea.xMin, randomArea.xMax), Random.Range(randomArea.yMin, randomArea.yMax));
        return randomPosition;
    }

    void Destroy()
    {
        Destroy(this.gameObject);
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
