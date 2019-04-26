using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

//! Ustawienia fal wrogów
/** Klasa z ustawieniami wrogich fal */
public class WaveConfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    /** Zwraca model wroga */
    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    /** zwraca listę zawierającą wszystkie punkty drogi wrogiej jednostki */
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    /** Zwraca zmienną przechowującą informacje o tym, co ile sekund pojawia się kolejny wróg */
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    /** Zwraca losową wartość z informacją za jaki czas poajwi się kolejna fala wrogów  */
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    /** Zwraca ilość wrogów w fali */
    public int GetNumberOfEnemies() { return numberOfEnemies; }

    /** Zwraca szybkość wrogów w fali */
    public float GetMoveSpeed() { return moveSpeed; }


}
