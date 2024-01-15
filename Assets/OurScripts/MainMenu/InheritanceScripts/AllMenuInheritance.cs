using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllMenuInheritance : MonoBehaviour
{
    [HideInInspector] public bool Active;
    public void PlayGame()
    {
        SceneManager.LoadScene("TestSpel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Active = false;
    }

}
