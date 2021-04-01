using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


    }


    // this code links into unitys animator
    public void Smash() {

            anim.SetBool("smash", true);
        StartCoroutine(breakCo());

    }


             IEnumerator breakCo()
    {

        yield return new WaitForSeconds(.3f);
            this.gameObject.SetActive(false);
    }



}
