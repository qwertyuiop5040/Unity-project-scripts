using UnityEngine;
using System.Collections;
/**
 * Henry Wang
 * Apply to first person shooter
 * Checks to see if player is near food by raycasting.
 * Remember to tag coconuts as food
 */
public class FoodEater : MonoBehaviour {
	public GUIText food;//replace with actual graphic
	void Start () {}//do nothing
	
	/**
	 * Casts a ray to check for coconuts.
	 */
	void Update () {
		RaycastHit hit;//raycast
		if(Physics.Raycast (transform.position, transform.forward,
		out hit, 3)) {
			if(hit.collider.gameObject.tag=="food"){
				food.SendMessage("EatFood");//invokes the eatFood method in the FoodTextScript. 
				//Should be replaced with something less plain and better.
				Destroy(hit.collider.gameObject);
			}
		}
	}
	
	/** 
	 * This technically works, but has a hard time working because the camera is
	 * placed far above ground and for some reason doesnt interact with the cocnuts smoothly.
	 * Feel free to uncomment this to replace raycasting for experimentation purposes.
	 * Try expanding the collider radius/range to see if it works. For some reason it didn't work for me.
	public void OnCollisionEnter(Collision theObject) {
		print ("hi"+theObject.gameObject.tag+(++i));
		if(theObject.gameObject.tag=="Player"){
			print ("passed");
			GameObject.Find("FoodText").SendMessage("EatFood");
			DestroyObject(gameObject);
		}
	}*/
}
