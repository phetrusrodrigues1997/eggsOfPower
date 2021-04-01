using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Allows users to select a character in  the character selecting menu.
**/
public class CharacterPicker : MonoBehaviour
{
    public GameObject playerPrefab;
    public void onBtnClick()
    {
        moveusers.Instance.playerPrefab = playerPrefab;
    }

}
