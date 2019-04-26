using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Odtwarzanie muzyki w grze
/** Klasa kontroluje, żeby w danej chwili tylko jeden obiekt muzyczn był aktywny na scenie */
public class MusicPlayer : MonoBehaviour {

	
	void Awake () {
        SetUpSingleton();
	}
    /** Dba o to, żeby tylko muzyka leciała tylko z jednego źródła jednocześnie */
    private void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
