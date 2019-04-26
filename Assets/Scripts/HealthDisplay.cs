using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//! Punkty życia gracza

    /** Klasa odpowiedzialna za wyświetlanie punktów życia na ekranie */

public class HealthDisplay : MonoBehaviour {

    Text healthText;
    Player player;

    /** Ustawia dane w zmiennych */
    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    /** Wyświetla bierzące dane na ekranie w każdej klatce */
    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
