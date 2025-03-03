using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneManager : MonoBehaviour
{
    private static PlaySceneManager instance;
    public static PlaySceneManager Instance { get { return instance; } }

    public PlayerController player;

    public Gate gate;

    public GameObject expOrb;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
