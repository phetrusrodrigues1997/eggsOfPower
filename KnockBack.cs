using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class KnockBack : MonoBehaviourPun
{

    public float thrust;
    public float knockTime;
    public float damage;
    public PhotonView photonView;
    private bool ignoreDamage;





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (photonView.IsMine)
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            ignoreDamage = false;

            ownHit(other);
            potHit(other);
            arrowHit(other);
            enemyHit(other);
        }
    }
        private void ownHit(Collider2D other)
        {
            if (other.gameObject.CompareTag("bullet") && this.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<Arrow>().getID() == photonView.ViewID)
                {
                    Physics2D.IgnoreLayerCollision(8, 9, true);
                    ignoreDamage = true;
                }
            }
        }
        private void potHit(Collider2D other)
        {
            if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
            {
             other.GetComponent<pot>().Smash();
            }
        }
        private void arrowHit(Collider2D other)
        {

            if (other.gameObject.CompareTag("bullet"))
            {
                Rigidbody2D hit = GetComponent<Rigidbody2D>();
                if (hit != null)
                {
                   Vector2 difference = hit.transform.position - transform.position;
                   difference = difference.normalized * thrust;
                  hit.AddForce(difference, ForceMode2D.Impulse);

                   if (this.gameObject.CompareTag("enemy"))
                   {
                       hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                       GetComponent<Enemy>().Knock(hit, knockTime, damage);
                   }
                   if (this.gameObject.CompareTag("Player") && !ignoreDamage)
                   {
                    Debug.Log("hit");
                        if (this.gameObject.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                        {
                            hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                            GetComponent<PlayerMovement>().Knock(knockTime, damage);
                        }
                    }
                }
            }

        }
        private void enemyHit(Collider2D other)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
                Rigidbody2D hit = GetComponent<Rigidbody2D>();
                if (hit != null)
                {
                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);

                    if (this.gameObject.CompareTag("Player"))
                    {
                        if (this.gameObject.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                        {
                            hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                            GetComponent<PlayerMovement>().Knock(knockTime, damage);
                        }
                    }
                }
            }
        }
    }
