using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTexture : MonoBehaviour {

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

			// Get texture from the canvas
			Texture2D texture = (canvas.GetComponent<Renderer> ().material.mainTexture as Texture2D);
			if (texture != null) {
				// Get bytes of the texture
				byte[] bytes = texture.EncodeToPNG ();
				// Call C++ method to save the texture to file
				MyPlugin.Save (bytes, (uint)bytes.Length, path
				+ string.Format ("{0:yy-MM-dd-mm-ss}", System.DateTime.Now) + MyPlugin.FILE_TYPE);
			}
		}
	}
}
