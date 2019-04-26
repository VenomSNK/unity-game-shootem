using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Niszczenie pociskow
/** Klasa odpowiedzialna za znikanie pocisków, po wylocie poza obszar objęty przez kamerę */
public class Shredder : MonoBehaviour {

    /** Niszczy obiekt pocisku po zetknięciu z modelem "niszczarki" ustawionej poza widokiem gracza */
	private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
