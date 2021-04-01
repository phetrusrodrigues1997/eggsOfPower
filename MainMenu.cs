using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   //load Map1 when user clicks play
    public void Play()
    {
        SceneManager.LoadScene("Map1");




    }
    //close application when user clicks exit
    public void Exit()
    {

        Application.Quit();
        Debug.Log("Exit");
    }




}
