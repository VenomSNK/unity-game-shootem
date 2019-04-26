using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//! Ładownie scen w grze
/** Funkcje odpowiadające za wczytywanie się poszczególnych scen */
public class Level : MonoBehaviour {

    [SerializeField] float delayInSeconds = 2f;


    /** Włącza menu startowe */
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
		
    /** Włącza grę */
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        if(FindObjectOfType<GameSession>())
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
    }

    /** Włącza ekran końca gry */
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    /** Odczekuje chwilę przed włączeniem ekranu końcowego */
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    /** Wyłącza aplikację */
    public void QuitGame()
    {
        Application.Quit();
    }
}

