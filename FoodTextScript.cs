using UnityEngine;
using System.Collections;
/**
 * Henry Wang
 * Apply to the food text thing
 * Increments and updates the text as player collects food.
 */
public class FoodTextScript : MonoBehaviour {
	public int food=-1;//starts at -1 because it will increment once at Start
	const int MAX_FOOD=25;
	void Start () {
		EatFood();//displays food and sets food at zero
	}
	void Update (){}//do nothing
	
	/**
	 * Increments food by 1, then updates text
	 */
	void EatFood(){
		if((++food)>MAX_FOOD)food=MAX_FOOD;
		guiText.text="Food: "+food;
		guiText.enabled=true;
	}
}
