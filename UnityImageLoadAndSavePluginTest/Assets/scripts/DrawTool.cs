using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTool : MonoBehaviour {
	public ProcessTexture.DrawTools drawTool;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {		
			ProcessTexture.drawTool = drawTool;
		}
	}
}
