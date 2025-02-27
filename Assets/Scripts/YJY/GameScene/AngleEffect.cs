using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleEffect : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Angle");
        }
    }
}
