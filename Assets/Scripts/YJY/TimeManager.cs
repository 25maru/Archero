using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public double timeSeconds = 0;

    private void Update()
    {
        timeSeconds = TimeSpan.FromTicks(DateTime.UtcNow.Ticks).TotalSeconds;
    }
}
