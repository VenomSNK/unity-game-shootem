using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Zliczanie wyniku

/** Zliczanie wyniku gracza oraz dbanie o obecność tylko jednej sesji gry jednocześnie*/

public class GameSession : MonoBehaviour {

    int score = 0;

    
    private void Awake()
    {
        SetUpSingleton();
    }

    /** Upewnia sie, że w toku jest wyłącznie jedna sesja gry.   */
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    /** Zwraca wynik gracza */
    public int GetScore()
    {
        return score;
    }

    /** Dodaje punkty do wyniku */
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    /** Reset gry */
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
