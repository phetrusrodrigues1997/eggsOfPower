using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public static SpawnManager instance;
    private GameObject playerPrefab;
    public GameObject coin;
    public GameObject enemy;
    private int Level;
    private object[] coins;
    private object[] enemies;
    public int startingAmountEnemies;
    public int startingAmountCoins;
    private int numOfCoins, numOfEnemies, rndDegree;
    private float speed;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI EnemyText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        playerPrefab = moveusers.Instance.playerPrefab;
        SpawnPlayer();
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnCoins();
        SpawnEnemies();
        }
        else
        {
            UpdateValues();
        }

    }
    void Update()
    {
        UpdateValues();
        if (PhotonNetwork.IsMasterClient)
        {
            if (numOfCoins == 0 && numOfEnemies == 0)
            {
                Level += 1;

                SpawnCoins();
                SpawnEnemies();
            }
        }
        else
        {
            UpdateValues();
        }

    }

    private void UpdateValues()
    {
        coins = GameObject.FindGameObjectsWithTag("coins");
        numOfCoins = coins.Length;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        numOfEnemies = enemies.Length;
        CoinText.text = "x" + numOfCoins.ToString();
        EnemyText.text = "x" + numOfEnemies.ToString();
    }
    public void SpawnCoins()
    {
        while (numOfCoins < startingAmountCoins + Level *2)
        {

            rndDegree = Random.Range(0, 360);
            PhotonNetwork.Instantiate(coin.name, GetUnitOnCircle(rndDegree, 12), Quaternion.identity);
            coins = GameObject.FindGameObjectsWithTag("coins");
            numOfCoins = coins.Length;
        }
    }
    public void SpawnEnemies()
    {

        while (numOfEnemies < startingAmountEnemies + Level)
        {
            speed = (float)(1.4 + Level * 0.1);
            enemy.GetComponent<log>().changeSpeed(speed);
            rndDegree = Random.Range(0, 360);
            PhotonNetwork.Instantiate(enemy.name, GetUnitOnCircle(rndDegree, (float)4.9), Quaternion.identity);
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            numOfEnemies = enemies.Length;
        }
    }
    private Vector2 GetUnitOnCircle(float angleDegrees, float radius)
    {

        // initialize calculation variables
        float _x = 0;
        float _y = 0;
        float angleRadians = 0;
        Vector2 _returnVector;

        // convert degrees to radians
        angleRadians = angleDegrees * Mathf.PI / 180.0f;

        // get the 2D dimensional coordinates
        _x = radius * Mathf.Cos(angleRadians) + 1.5f;
        _y = radius * Mathf.Sin(angleRadians);

        // derive the 2D vector
        _returnVector = new Vector2(_x, _y);

        // return the vector info
        return _returnVector;
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);
    }
}
