using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageController : MonoBehaviour
{
    public bool isRed = true;
    public StageButtonAction Red;
    public StageButtonAction Blue;

    public GameObject RedParticle;
    public GameObject BlueParticle;

    public WindZone Redwind;
    public WindZone Bluewind;

    public void ChangeisRed()
    {
        isRed = !isRed;
        if (isRed)//빨간 버튼이 눌릴 시
        {
            Red.DownThisButton();
            Blue.UpThisButton();
            RedParticle.SetActive(true);
            BlueParticle.SetActive(false);
            Redwind.isUP = true;
            Bluewind.isUP = false;
        }
        else
        {
            Red.UpThisButton();
            Blue.DownThisButton();
            RedParticle.SetActive(false);
            BlueParticle.SetActive(true);
            Redwind.isUP = false;
            Bluewind.isUP = true;
        }
    }
}
