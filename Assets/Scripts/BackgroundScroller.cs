using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Ruchome tło 

    /** Klasa odpowiedzialna ze poruszanie sie tla */

public class BackgroundScroller : MonoBehaviour {

    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offSet;


	/** Start wstawia wartosci do zmiennych oraz ustawia wielkosc okna gry */
	void Start () {
        Screen.SetResolution(540, 960, false);
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
	}
	
	/** Update przesuwa w kazdej klatce w osi Y tło o zmienna offSet */
	void Update () {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
	}
}
