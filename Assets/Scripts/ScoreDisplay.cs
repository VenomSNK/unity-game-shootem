using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//! Wyswietlanie wyniku gracza na ekranie
/** Funkcja odpowiedzialna za wyświetlanie na ekranie wyniku uzyskanego przez gracza */
public class ScoreDisplay : MonoBehaviour {

    Text scoreText;
    GameSession gameSession;

	/** Przypisanie danych do zmiennych */
	void Start () {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
	}
	
	/** Zmiana wyniku na ekranie, w zależności od obecnego wyniku, uaktualniane w kazdej klatce */
	void Update () {
        scoreText.text = gameSession.GetScore().ToString();
	}
}
