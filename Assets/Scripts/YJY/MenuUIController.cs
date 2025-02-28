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
        if (isMenuOn) { 
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        menu.SetActive(isMenuOn);
    }
}
