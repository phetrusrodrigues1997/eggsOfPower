using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
//using SceneManager;

public class moveusers : MonoBehaviourPunCallbacks
{
    public static moveusers Instance;
    public GameObject playerPrefab;
    public string userName;
    public int score;
    public float timeleft;
    public float milliseconds;
    public bool playerUIActive;
    public bool deathUIActive;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


}
