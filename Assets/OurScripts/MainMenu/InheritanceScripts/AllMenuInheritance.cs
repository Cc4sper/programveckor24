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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 1);
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
