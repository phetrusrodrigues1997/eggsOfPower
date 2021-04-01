using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //[SerializeField] private float m_Duration = 3f;
    public float speed;
    public Rigidbody2D MyRigidbody;
    private int ID;

/**
The setup method will begin the calculations needed to display the arrow in the game
**/

    public void Setup(Vector2 velocity, Vector3 direction, int id)
    {
        MyRigidbody.velocity = velocity.normalized * (speed + 3.5f);
        transform.rotation = Quaternion.Euler(direction);
        ID = id;
    }
    public int getID()
    {
        return ID;
    }

    /**
    The update method will destroy the arrows 2.9 seconds after being shot
    **/
    private void Update()
    {
        if (MyRigidbody.velocity.x == 0 || MyRigidbody.velocity.y == 0)
        {
            StartCoroutine(DoFade());
        }
    }

// Timer
    IEnumerator DoFade()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.9f);
            arrowDestroy();
        }
    }

    private void arrowDestroy()
    {
        Debug.Log("Destroyed");
        Destroy(this.gameObject);
    }

    /**
    This collision method will stop displaying the arrow in the game once it hits either the enemy
    or players.
    **/
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("collision works");
            Destroy(this.gameObject, 0f);
        }
        else if (collision.gameObject.tag == "trees")
        {
            Destroy(this.gameObject, 0f);
        }

    }



}
