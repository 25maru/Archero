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

    public WindZone Right;
    public WindZone Left;

    public void ChangeisRed()
    {
        isRed = !isRed;
        if (isRed)//빨간 버튼이 눌릴 시
        {
            Blue.UpThisButton();
            RedParticle.SetActive(true);
            BlueParticle.SetActive(false);
            Right.isUP = true;
            Left.isUP = false;
        }
        else
        {
            Red.UpThisButton();
            RedParticle.SetActive(false);
            BlueParticle.SetActive(true);
            Right.isUP = false;
            Left.isUP = true;
        }
    }
}
