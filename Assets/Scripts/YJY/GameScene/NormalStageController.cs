using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageController : MonoBehaviour
{
    public bool isRed = true;
    public List<StageButtonAction> Red;
    public List<StageButtonAction> Blue;

    public List<GameObject>  RedParticle;
    public List<GameObject> BlueParticle;

    public List<WindZone>  Redwind;
    public List<WindZone> Bluewind;

    public void ChangeisRed()
    {
        isRed = !isRed;
        if (isRed)//빨간 버튼이 눌릴 시
        {
            foreach (StageButtonAction r in Red)
            {
                r.DownThisButton();
            }
            foreach (StageButtonAction b in Blue)
            {
                b.UpThisButton();
            }
            foreach (GameObject rp in RedParticle)
            {
                rp.SetActive(true);
            }
            foreach (GameObject bp in BlueParticle)
            {
                bp.SetActive(false);
            }
            foreach (WindZone rw in Redwind)
            {
                rw.isUP = true;
            }
            foreach (WindZone bw in Bluewind)
            {
                bw.isUP = false;
            }
        }
        else
        {
            foreach (StageButtonAction r in Red)
            {
                r.UpThisButton();
            }
            foreach (StageButtonAction b in Blue)
            {
                b.DownThisButton();
            }
            foreach (GameObject rp in RedParticle)
            {
                rp.SetActive(false);
            }
            foreach (GameObject bp in BlueParticle)
            {
                bp.SetActive(true);
            }
            foreach (WindZone rw in Redwind)
            {
                rw.isUP = false;
            }
            foreach (WindZone bw in Bluewind)
            {
                bw.isUP = true;
            }
        }
    }
}
