using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorSpawner : MonoBehaviour {

	// public variables
	public float secondsBetweenSpawning = 0.1f;
	public GameObject[] spawnObjects; // what prefabs to spawn

	private float nextSpawnTime;

	// Use this for initialization
	void Start ()
	{
		// determine when to spawn the next object
		nextSpawnTime = Time.time + secondsBetweenSpawning;
	}

	// Update is called once per frame
	void Update ()
	{
		// if time to spawn a new game object
		if (Time.time >= nextSpawnTime) {
			// Spawn the game object through function below
			MakeThingToSpawn ();

			// determine the next time to spawn the object
			nextSpawnTime = Time.time + secondsBetweenSpawning;
		}	
	}

	void MakeThingToSpawn ()
	{
		// determine which object to spawn
		int objectToSpawn = UnityEngine.Random.Range (0, spawnObjects.Length);

		// actually spawn the game object
		GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], 
			transform.position, transform.rotation) as GameObject;
		// set color of object
		spawnedObject.GetComponent<Renderer> ().material.color = UnityEngine.Random.ColorHSV();
		// make the parent the spawner so hierarchy doesn't get super messy
		spawnedObject.transform.parent = gameObject.transform;
	}
}
