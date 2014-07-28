using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * Henry Wang
 * Apply to first person shooter
 * Keeps track and updates the supplies the player has.
 */
public class Supplies : MonoBehaviour {
	/**
	 * These fields can be replaced with array, and more fields can be added. However, make sure you update the
	 * switch function as well.
	 */
	int ax=0;//count for how many axes, ropes, etc you have
	int rope=0;
	int bucket=0;
	int wood=0;
	public GUIText inv;
	void Start () {
		updateText();
	}
	/**
	 * Casts a ray to check for objects.
	 */
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast (transform.position, transform.forward,
		out hit, 3)) {
			switch(hit.collider.gameObject.tag){
			case "ax"://make sure you tag each object
				ax++;
				break;
			case "rope":
				rope++;
				break;
			case "bucket":
				bucket++;
				break;
			case "wood":
				wood++;
				break;
			default:
				return;
			}
			updateText();
			Destroy(hit.collider.gameObject);
		}
	}
	/**
	 * Updates the text everytime an item is collected.
	 */
	void updateText(){
		if(!inv.enabled)inv.enabled=true;
		string temp="Ax: "+ax+"\n"+"Rope: "+rope+"\n"+"Bucket: "+bucket+"\n"+"Wood: "+wood;
		inv.text=temp;
	}
}
