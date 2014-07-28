using UnityEngine;
using System.Collections;
/**
 * Henry Wang
 * Apply to a tree. The tree must be individually placed onto terrain. Mass place trees or the add trees thing in
 * terrain will NOT work.
 */ 
public class CoconutDropper : MonoBehaviour {
	public Rigidbody coconutPrefab;
	public int coconutsLeft=10;
	void Start () {}//do nothing
	void Update () {}//do nothing
	
	/**
	 * Makes coconut drop. You MUST tag rocks as coconut, unless you decide to change the script. 
	 */
	public void OnCollisionEnter(Collision theObject) {
		if(theObject.gameObject.tag=="coconut"&&coconutsLeft>0){
			coconutsLeft--;
			float dx=Random.Range(-3.0f,3.0f);//change in x
			float dz=Random.Range(-3.0f,3.0f);//change in z
			dx=(Mathf.Abs(dx)>=1.0f)?dx:1.0f;
			dz=(Mathf.Abs(dz)>=1.0f)?dz:1.0f;
			Rigidbody newCoconut=Instantiate (coconutPrefab,
				new Vector3(transform.position.x+dx,transform.position.y+15,transform.position.z+dz),
				transform.rotation) as Rigidbody;
		}
	}	
}
