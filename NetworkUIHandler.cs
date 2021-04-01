using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class NetworkUIHandler : MonoBehaviourPunCallbacks
{

    public TMP_InputField createRoomInput, joinRoomInput, userNameInput;



    public void onClickJoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom(joinRoomInput.text, roomOptions, TypedLobby.Default);
    }
    public void onClickCreateRoom()
    {
        if (createRoomInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 10 }, null);
        }

    }
    public override void OnJoinedRoom()
    {
        Debug.Log("We are connected to the room");


        PhotonNetwork.LocalPlayer.NickName = userNameInput.text;




        PhotonNetwork.LoadLevel("Map1");



        Time.timeScale = 1;
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log(" roomFailed " + returnCode + " Message " + message);
    }













}
