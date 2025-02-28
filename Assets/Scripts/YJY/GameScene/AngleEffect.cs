using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleEffect : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var playData = PlaySceneManager.Instance.player.GetComponent<PlayerStat>();
            playData.Heal(playData.GetMaxHealth());

            PlaySceneManager.Instance.player.ChangeHealthUI();
        }
    }
}
