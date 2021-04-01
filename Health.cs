using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Health : MonoBehaviourPunCallbacks, IPunObservable
{
    public float health;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }else
        {
            try
            {
               health = (float)stream.ReceiveNext();
            } catch (Exception e)
            {
                print("error");
            }

        }
    }
    public void TakeDamage(float damage)
    {
        damage = damage - 0.843f;
        health -= damage;
        if (health <= 0)
        {

            Destroy(this);





        }
    }
    public float GetHealth()
    {
        return health;
    }
    // Start is called before the first frame update
    /**
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    */
}
