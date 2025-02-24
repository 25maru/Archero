using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public GameObject menu;
    bool isMenuOn = false;

    private void Start()
    {
        menu.gameObject.SetActive(isMenuOn);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOn = !isMenuOn;
            menu.gameObject.SetActive(isMenuOn);
        }
    }
}
