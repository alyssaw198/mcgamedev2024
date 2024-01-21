using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Seb's tester");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Quit Game");
    }

    public void Next()
    {
        SceneManager.LoadScene("Home");
    }

    public void Lore2()
    {
        SceneManager.LoadScene("Lore 1");
    }

    public void Lore()
    {
        SceneManager.LoadScene("Lore");
    }
}
