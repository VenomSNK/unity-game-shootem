using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//! Zadawanie obrażeń przez wrogów
/** Klasa zwraca wartośc zadanych przez wrogów obrażeń */
public class DamageDealer : MonoBehaviour {

    [SerializeField] int damage = 20;

    /** Zwraca wartość obrażeń */
	public int GetDamage()
    {
        return damage;
    }

    /** Niszczy gracza, jeśli otrzyma zbyt dużo obrażeń */
    public void Hit()
    {
        Destroy(gameObject);
    }
}
