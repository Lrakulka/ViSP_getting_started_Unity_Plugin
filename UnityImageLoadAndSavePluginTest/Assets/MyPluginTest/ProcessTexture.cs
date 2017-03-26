using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessTexture : MonoBehaviour {
	// Radius of the projectile mark (Point)
	public int pointRadius = 3;
	// Radius of the circle
	public int circleRadius = 3;

	public enum DrawTools {Point, Circle, Line};

	public static DrawTools drawTool = DrawTools.Point;
	// Contains previous position of the collision
	private Vector2 privPosit;

	// Use this for initialisation
	void Start() { 
		// Initialisate canvas with virtual dublicat of the default texture
		// Get default texture
		Texture2D savedTexture = GetComponent<Renderer> ().material.mainTexture as Texture2D;
		// Prepare the dublicat texture conteyner
	    Texture2D newTexture = new Texture2D(savedTexture.width, savedTexture.height, TextureFormat.ARGB32, false);
	    // Load default texture to the dublicate
	    newTexture.SetPixels(0, 0, savedTexture.width, savedTexture.height, savedTexture.GetPixels());
		newTexture.Apply ();
		// Set dublicat to the canvas
		GetComponent<Renderer> ().material.mainTexture = newTexture;
	}

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {		
			// Get color of the projectile
			Color projectileColor = newCollision.gameObject.GetComponent<Renderer> ().material.color;
			// destroy the projectile
			//Destroy (newCollision.gameObject);

			// Get Canvas texture
			Texture2D texture = (GetComponent<Renderer> ().material.mainTexture as Texture2D);
			if (texture != null) {
				// Find colligion coordinates on the texture
				Vector2 currPosition = findPosition(texture, newCollision.contacts [0]);
				DrawTool (texture, currPosition, drawTool, projectileColor);

				// Apply changes to the canvas
				texture.Apply ();
				// Set texture to the canvas
				GetComponent<Renderer> ().material.mainTexture = texture;
			}
		}
	}

	private void DrawTool (Texture2D texture, Vector2 currPosition, DrawTools drawTool, Color projectileColor) {
		switch (drawTool) {
		case DrawTools.Point:
			// Draw solid circle on the texture
			BitmapDrawingExtensions.DrawFilledCircle (texture, (int)currPosition.x, 
				(int)currPosition.y, pointRadius, projectileColor);
			currPosition = Vector2.zero;
			break;
		case DrawTools.Circle:
			// Draw circle on the texture
			BitmapDrawingExtensions.DrawCircle (texture, (int) currPosition.x, 
				(int) currPosition.y, circleRadius, projectileColor);
			privPosit = Vector2.zero;
			break;
		case DrawTools.Line:
			if (privPosit != Vector2.zero) {
				// Draw line on the texture
				BitmapDrawingExtensions.DrawLine (texture, privPosit, currPosition, projectileColor);
			}
			privPosit = currPosition;
			break;
		}
	}

	// Find colligion coordinates on the texture
	private Vector2 findPosition(Texture texture, ContactPoint contact) {
		Vector3 pos = contact.point;
		Vector3 objPos = transform.position;
		Vector3 size = GetComponent<Renderer> ().bounds.size;
		Vector2 position = new Vector2 ((objPos.x + size.x / 2 + pos.x) * (texture.width / size.x),
			                   (objPos.y + size.y / 2 - pos.y) * (texture.height / size.y));
		return position;
	}
}
