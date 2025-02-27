using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private bool isOpen = false;

    PlaySceneManager manager;
    Gate gate;

    private void Start()
    {
        manager = PlaySceneManager.Instance;
        gate = manager.gate;

        if (isOpen)
        {
            gate.Open();
        }
    }
}
