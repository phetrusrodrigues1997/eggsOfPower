using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class InnerPlayerUI : MonoBehaviourPunCallbacks
{
    #region Private Fields
    [Tooltip("UI Text to display Player's Name")]
    [SerializeField]
    private TextMeshProUGUI playerNameText;

    [Tooltip("UI Slider to display Player's Health")]
    [SerializeField]
    private Slider playerHealthSlider;

    [Tooltip("Player Health ")]
    [SerializeField]
    private Health health;



    #endregion

    public PhotonView photonView;

    void Start()
    {
        if (photonView.IsMine)
        {

            playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
            playerHealthSlider.value = health.GetHealth();
        }
        else
        {
            playerNameText.text = photonView.Owner.NickName;
            playerHealthSlider.value = health.GetHealth();

        }
    }
    void Update()
    {

           playerHealthSlider.value = health.GetHealth();



    }




}
