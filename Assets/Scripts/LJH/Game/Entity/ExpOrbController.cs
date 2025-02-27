using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpOrbController : MonoBehaviour
{
    CircleCollider2D coll;
    Transform target;

    int gold;
    int exp;
    float lerpWeight = 0f;
    bool isGain = false;

    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        target = PlaySceneManager.Instance.player.transform;
    }

    public void Init(int gold, int exp)
    {
        this.gold = gold;
        this.exp = exp;

        Vector3 vecRandom = Random.insideUnitCircle;
        Vector3 createPos = transform.position + vecRandom;

        StartCoroutine(CreateOrb(createPos));
    }

    IEnumerator CreateOrb(Vector3 CreatePos)
    {
        while (lerpWeight < 1f)
        {
            lerpWeight += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, CreatePos, lerpWeight);

            Vector3 distance = CreatePos - transform.position;
            if (distance.magnitude <= 0f)
                break;

            yield return null;
        }
    }

    IEnumerator GainOrb()
    {
        lerpWeight = 0;

        while (lerpWeight < 1f)
        {
            lerpWeight += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position, lerpWeight);

            Vector3 distance = target.position - transform.position;
            if (distance.magnitude < 1f)
                break;

            yield return null;
        }

        PlayerStat playerStat = PlaySceneManager.Instance.player.GetComponent<PlayerStat>();

        playerStat.GetExp(exp);
        playerStat.GetGold(gold);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isGain)
            {
                StopAllCoroutines();

                isGain = true;
                StartCoroutine(GainOrb());
            }
        }
    }
}
