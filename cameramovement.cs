using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using Photon.Pun;


/**
This class will conduct the calcuations needed for the camera movement.
**/
public class cameramovement : MonoBehaviourPun
{

    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;



    // Update is called once per frame
    void Update()
    {


        if (!photonView.IsMine)
            return;

        if(transform.position != target.position)
        {

            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);


            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);

            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);





        }



    }
}
