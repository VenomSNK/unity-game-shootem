using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Ustawienia wrogich statków

/** Metody opisuja zachowanie oraz statystyki wrogich statkow */

public class Enemy : MonoBehaviour {

    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;

    [Header("Shooting")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;

    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float deathSFXVolume = 0.75f;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float shootSFXVolume = 0.75f;


    /** Losuje w jakich odstepach czasu wrog strzela */
    void Start () {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		
	}
	
	/** W kazdej klatce sprawdza czy uplyna czas do nastepnego strzalu */
	void Update () {
        CountDownAndShoot();
	}

    /** Odlicza czas do wystrzału */
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    /** Wystrzeliwuje pocisk z okreslona predkoscia, odtwarza plik audio z dzwiekiem wystrzalu */
    private void Fire()
    {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSFXVolume);
    }


    /** Zadawanie obrazen graczowi przy kontakcie z wystrzelonym pociskiem */
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    /** Sprawdza czy wróg ma więcej punktów życia niż zero, jeśli nie usuwa go ze sceny */
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    /** Usuwa wroga ze sceny, jesli punkty życia spadną poniżej zera */
    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }
}
