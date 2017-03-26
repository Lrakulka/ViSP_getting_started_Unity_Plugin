using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTexture : MonoBehaviour {

	// Path to the texture
	[TextArea(1, 20)]
	public string path;

	// Our canvas
	public GameObject canvas;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {		

			// destroy the projectile
			Destroy (newCollision.gameObject);

			// Load Texture (Texture2D has no empty constructor)
			Texture2D texture = new Texture2D (1, 1);
			// Get texture size
			uint size = MyPlugin.GetSize (path + MyPlugin.FILE_TYPE);
			// Create array to store PNG's bytes
			byte[] bytes = new byte[size];
			// Call C++ method from DLL
			MyPlugin.Load(path + MyPlugin.FILE_TYPE, bytes, size);
			// Load texture to the game object
			texture.LoadImage (bytes);
			// Set texture to the canvas
			canvas.GetComponent<Renderer> ().material.mainTexture = texture;
		}
	}
}
