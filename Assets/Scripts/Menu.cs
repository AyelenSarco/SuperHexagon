using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GoToGameScene(){
        SceneManager.LoadScene("Game");
    }

    public void ExitGame(){
        Debug.Log("EXIT GAME");
        Application.Quit();
    }
}
