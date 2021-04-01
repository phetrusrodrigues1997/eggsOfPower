using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;


public class DeathScreenScript : MonoBehaviourPun
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    /**
    This method displays the minutes lasted in the game and how many points the Player
    collected.
    **/
    void Start()
    {
        float TL = 600f - moveusers.Instance.timeleft;
        int minutes = (int)(TL / 60f);
        int seconds = (int)(TL % 60);

        PhotonNetwork.Disconnect();
        scoreText.text = "Score: " + moveusers.Instance.score.ToString();
        timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public void btnOnClick()
    {
        moveusers.Instance.score = 0;
        SceneManager.LoadScene("Menu");
    }
}
