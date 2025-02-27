using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WindZoneManager : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    public bool isUP = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            int direction = isUP ? 1 : -1;
            collision.transform.position += new Vector3(0, speed * direction * Time.deltaTime, 0);
        }
    }
}
