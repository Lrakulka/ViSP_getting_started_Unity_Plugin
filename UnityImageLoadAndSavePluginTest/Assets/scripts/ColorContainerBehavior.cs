using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorContainerBehavior : MonoBehaviour {
	public int liveTimeMin = 5;
	public int liveTimeMax = 10;
	public float speed = 0.1f;
	public int NumberOfTrajectory = 180;
	public int spawnAreaZ = 10;
	public float stepByZ = 1f;
	public int a = 3;
	public int b = 3;

	private float nextMoveTime;
	private float liveTime;
	private double xToy;
	private Vector3 destination;
	private float e = 10f;

	// Use this for initialization
	void Start ()
	{
		// determine when to destroy the object
		liveTime = Time.time + UnityEngine.Random.Range (liveTimeMin, liveTimeMax);

		NumberOfTrajectory /= 2;
		float x = UnityEngine.Random.Range (-NumberOfTrajectory, NumberOfTrajectory);
		float y = (float) Math.Sqrt (NumberOfTrajectory * NumberOfTrajectory - x * x) + 0.001f;
		xToy = x / y;
		updatePosition (transform.localPosition.z + UnityEngine.Random.Range (0, spawnAreaZ));
		transform.localPosition = destination;
	}

	// Update is called once per frame
	void Update ()
	{
		// if time to spawn a new game object
		if (Math.Abs(transform.localPosition.sqrMagnitude - destination.sqrMagnitude) < e) {
			// Update destination of the object
			updatePosition (transform.localPosition.z);
		}	

		// if time to die the object destroys
		if (Time.time >= liveTime) {
			Destroy (gameObject);
		}
		transform.localPosition = Vector3.Lerp(transform.localPosition, 
			destination, speed * Time.deltaTime);
	}
		
	// When collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		// Only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {		
			// Set color of the projectile for projectiles
			Controller.projectilesColor = gameObject.GetComponent<Renderer> ().material.color;
			// Destroy the projectile
			Destroy (newCollision.gameObject);
			// Destroy collider
			Destroy(gameObject);
		}
	}

	private void updatePosition(float startZ) {
		float z = startZ + stepByZ;
		float y = (float) Math.Sqrt((2 * z * a * a * b * b / (a * a + xToy * xToy * b * b)));
		float x = (float) (y * xToy);
		destination = new Vector3(x, y, z);
	}
}
