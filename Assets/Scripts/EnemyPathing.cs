using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//! Kierunek poruszania się wrogów
/** Klasa odpowiada za poruszanie się wrogich jednostek po przydzielonych im ściezkach */
public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> waypoints;
    
    int waypointIndex = 0;

	/** Pobiera punkty drogi wroga */
	void Start () {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	/** Przesuwa wroga w każdej klatce */
	void Update ()
    {
        Move();
    }

    /** Pobiera informacje z obecnej fali wrogów */
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    /** Odpowiada za przemieszczanie się wroga w kierunku kolejnego punktu drogi */
    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
