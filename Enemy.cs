using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



public enum EnemyState
{

    idle,
    walk,
    attack,
    stagger
}



public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public Health health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public PhotonView photonView;

   public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        if (health.GetHealth() > 0)
        {
            StartCoroutine(knockCo(myRigidbody, knockTime));
            damage = damage + 0.35f;
            health.TakeDamage(damage);
        }
        else
        {



                PhotonNetwork.Destroy(photonView);
                Destroy(this);

        }


    }
    public void changeSpeed(float x)
    {
        moveSpeed = x;
    }



    private IEnumerator knockCo(Rigidbody2D myRigidbody, float knockTime)
    {

        if (myRigidbody != null)
        {

            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }

    }

}
