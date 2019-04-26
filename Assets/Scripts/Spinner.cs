using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!  Obrot pocisku
/** Klasa, ktora odpowiedzialna jest za obrot pocisku przeciwnika */
public class Spinner : MonoBehaviour
{
    [SerializeField] float speedOfSpin = 1f;

    void Update()
    {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
}


