using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonImpact : MonoBehaviour
{
    public Animator Player_Ani;
    public Animator Bright;

    public void OnClickStartButton()
    {
        Bright.SetBool("IsStart", true);
        Invoke("InvokeStartButton",1.2f);
    }
    void InvokeStartButton()
    {
        Player_Ani.SetBool("Player_Motion", true);
    }
}
