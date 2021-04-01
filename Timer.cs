using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeLeft = 0f;
    private bool running = false;
    public TextMeshProUGUI timeText;

    void Start()
    {
        Begin();
    }
    void Update()
    {
        if (running)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = GetMinutes().ToString("00") + ":" + GetSeconds().ToString("00");
            moveusers.Instance.timeleft = timeLeft;
            if(timeLeft <= 0)
            {
                running = false;

                SceneManager.LoadScene("VictoryScreen");
            }
        }

    }

    public void Begin()
    {
        if (!running)
        {
            timeLeft = 600f;
            running = true;
        }
    }
    public void Stop()
    {
        if (running)
        {

            running = false;
        }
    }


    public void Reset()
    {
        timeLeft = 0f;
        running = false;
    }

    public int GetMinutes()
    {
        return (int)(timeLeft / 60f);
    }

    public int GetSeconds()
    {
        return (int)(timeLeft % 60);
    }
    public float GetRawElapsedTime()
    {
        return timeLeft;
    }

}
