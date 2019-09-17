using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public float spawnRate = 1;
    private SpawnPoint[] spawnPoints;
    public GameObject ennemiPrefab0;
    public GameObject ennemiPrefab1;
    private float timeLeft = 0;
    // Use this for initialization
    void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeLeft = 1 / spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpawn();
	}

    private void UpdateSpawn()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft<=0)
        {
            if(Random.Range(0,2) == 0)
            {
                SpawnCube();
            }
            else
            {
                SpawnCylinder();
            }
            timeLeft = 1 / spawnRate;
        }
    }

    private void SpawnCube()
    {
        int spawnPointNumber = spawnPoints.Length;
        int randomPoint = Random.Range(0, spawnPointNumber);
        SpawnPoint selectedPoint = spawnPoints[randomPoint];
        Instantiate(ennemiPrefab0, selectedPoint.GetPosition(), selectedPoint.transform.rotation);
    }

    private void SpawnCylinder()
    {
        int spawnPointNumber = spawnPoints.Length;
        int randomPoint = Random.Range(0, spawnPointNumber);
        SpawnPoint selectedPoint = spawnPoints[randomPoint];
        Instantiate(ennemiPrefab1, selectedPoint.GetPosition(), selectedPoint.transform.rotation);
    }
}
