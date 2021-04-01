using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;



public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviourPun,IPunObservable
{

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject projectile;
    public Health health;
    private float angle;
    public PhotonView photonView;
    private Vector3 smoothMove;
    private GameObject sceneCamera;
    public GameObject playerCamera;


    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {

            moveusers.Instance.playerUIActive = true;
            sceneCamera = GameObject.Find("Main Camera");
            sceneCamera.SetActive(false);
            playerCamera.SetActive(true);
        }

        QualitySettings.vSyncCount = 1;
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            ProcessInputs();
       } else
        {
            smoothMovement();
        }



    }
    private void ProcessInputs()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            photonView.RPC("RPC_Shoot", RpcTarget.All);
        }
        //(else) if you want player to stop when attacking
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }
    [PunRPC]
    void RPC_Shoot()
    {
        StartCoroutine(AttackCo());
    }
    private void smoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        } else if (stream.IsReading)
        {
            smoothMove = (Vector3) stream.ReceiveNext();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coins"))
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator AttackCo()
    {
        GetComponent<AudioSource>().Play(0) ;
        //animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }

    }

    private void MakeArrow()
    {

        Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(temp, ChooseArrowDirection(), photonView.ViewID);
    }



      Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);

    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);

        }
    }

     void MoveCharacter()
    {
        change.Normalize();

        myRigidbody.MovePosition(
            transform.position + change * (speed - 10.3f) * Time.deltaTime

            ) ;


    }


    public void Knock( float knockTime, float damage)
    {

        {
            health.TakeDamage(damage);
            if (health.GetHealth() > 0)
            {
                StartCoroutine(knockCo(knockTime));
            }
            else
            {
                if (photonView.IsMine)
                {
                    playerCamera.SetActive(false);
                    SceneManager.LoadScene("DeathScreen");
                    PhotonNetwork.Destroy(photonView);
                }
            }
        }
    }


    private IEnumerator knockCo(float knockTime)
    {

        if (myRigidbody != null)
        {

            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;


        }

    }




}
