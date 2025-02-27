using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrainController : MonoBehaviour
{
    void Update()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));

        if(point.x > 2.1)
        {
            point.x = 2.1f;
        }
        if(point.x < -2.1)
        {
            point.x = -2.1f;
        }
        transform.position = new Vector3(point.x,0,0);
    }
}
