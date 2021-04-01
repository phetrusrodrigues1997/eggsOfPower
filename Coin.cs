using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin: MonoBehaviour {
    public int coinValue = 1;

    /**
    When tringerred, this method will increase the score for every collected coin,
    and provice the sound effects for the coins.
    **/
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            ScoreManager.instance.ChangeScore(coinValue);
            Debug.Log("Hello");
            GameObject.Find("CoinAudio").GetComponent<AudioSource>().Play(0);

        }
    }




}
