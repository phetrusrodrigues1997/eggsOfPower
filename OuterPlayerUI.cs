using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OuterPlayerUI : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [Tooltip("Death UI")]
    [SerializeField]
    private GameObject deathUi;
    [Tooltip("Player UI")]
    [SerializeField]
    private GameObject playerUi;

    public void transition()
    {
        playerUi.SetActive(false);
        deathUi.SetActive(false);
        timer.Stop();
    }
}
