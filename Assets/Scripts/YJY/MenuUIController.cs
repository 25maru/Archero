using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public GameObject menu;
    bool isMenuOn = false;

    private void Start()
    {
        menu.SetActive(isMenuOn);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        isMenuOn = !isMenuOn;
        menu.SetActive(isMenuOn);
    }
}
