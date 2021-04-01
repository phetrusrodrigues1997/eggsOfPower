using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerConnect : MonoBehaviourPunCallbacks
{

    public GameObject sectionView1, sectionView2, sectionView3;


    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings ();

        Debug.Log("Connecting to photon.....");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We Are Connected To Master");
    }
    public override void OnJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        Debug.Log("On Joined Lobby");

    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        if (sectionView1.active)
        {
            sectionView1.SetActive(false);
        }
        if (sectionView2.active)
        {
            sectionView2.SetActive(false);
        }
        sectionView3.SetActive(true);
        Debug.Log("Disconnected from photon services");
    }


}
