using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Ustawienia gracza
/** Klasa odpowiedzialna za ustawienia gracza oraz wszystkie funkcje jego statku */
public class Player : MonoBehaviour {

    //configuration parameters
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 100;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.75f;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0, 1)] float shootSFXVolume = 0.25f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

	/** Ustawia zakres ruchu gracza */
	void Start () {
        SetUpMoveBoundaries();
	}

    /** W każdej klatce pozwala graczowi na poruszanie się i/lub strzelanie */
    void Update () {
        Move();
        Fire();
	}

    /** Sprawdza czy gracz odniósł obrażenia */
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    /** Zadaje graczowi otrzymane obrażenia */
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();

        }
    }

    /** Usuwa gracza ze sceny, jeśli odniósł zbyt dużo obrażeń. Ładuje ekran końca gry */
    private void Die()
    {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }

    /** Zwraca punkty życia gracza */
    public int GetHealth()
    {
        if(health < 0) { return 0; }
        return health;
    }

    /** Przypisuje przyciski, którymi użytkownik strzela */
    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    
    /** Model strzelania */
    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject laser = Instantiate(
                   laserPrefab,
                   transform.position,
                   Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSFXVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    /** Model poruszania się */
    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPOS = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPOS = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax); ;
        transform.position = new Vector2(newXPOS, newYPOS);
    }
    
    /** Ustawia granice poruszania się gracza */
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
