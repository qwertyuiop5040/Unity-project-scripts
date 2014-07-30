using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This script manages the inventory which has drag and drop functionality.
 * BE AWARE THAT THE Y VALUES OF UNITY FOR DRAWING TEXTURE2Ds work differently from the mouse Y values.
 * Texture 2Ds work like this
 * |y values
 * |0
 * |10
 * |20  
 * |30   5 10 15 20 25 30 x values
 * -------------------------------
 * 
 * Mouse coordinates work like this:
 * |y values
 * |30
 * |20
 * |10
 * |0   5 10 15 20 25 30 x values
 * ----------------------------------
 * add script to player
 */
public class Inventory2 : MonoBehaviour {
	public Texture2D square;
	public Texture2D branch;
	public Texture2D bucket;
	
	public const int BOX_WIDTH=115;//the width of inventory square
	public const int BOX_HEIGHT=115;//height ofinventory square
	public const int START_X=20;//x value in which it starts
	public static int START_Y;//y value in which it starts
	public const int NUM_RECTS=6;//number of inventory slots
	public const string BRANCH="branch";//string value of each type of object
	public const string BUCKET="bucket";
	
	private Rect fullInvRect;//rectangle containing the full inventory
	private Rect[] invRects=new Rect[NUM_RECTS];//rectangle of individual inventory slots
	public static ArrayList inventoryList = new ArrayList();//list of strings of itemms in inventory
	private bool startedDrag=false;//whether a drag has started or not
	private int dragIndex=0;//the index of the object beign dragged
	/**
	 * Initializes rectangles and rectangle array
	 */
	void Start () {
		START_Y=Screen.height-125;
		AddItem("bucket");//test object feel free to remove
		AddItem("branch");//test object
		for(int i=0;i<NUM_RECTS;i++){
			invRects[i]=new Rect(START_X + BOX_WIDTH*i,START_Y, BOX_WIDTH, BOX_HEIGHT);
		}
		fullInvRect=new Rect(START_X,START_Y,BOX_WIDTH*NUM_RECTS,BOX_HEIGHT);
		//print (fullInvRect.xMin+" "+fullInvRect.yMin+" "+fullInvRect.xMax+" "+fullInvRect.yMax);
	}
	/**
	 * Checks for drag and drop
	 */
	void Update () {
		Vector3 mousePos=new Vector3(Input.mousePosition.x,Screen.height-Input.mousePosition.y);
		//y value is inverted because unity mouseY values use essentially a cartesian graph
		if(Input.GetMouseButtonDown(0)){//begin drag
			//print (Input.mousePosition.x+" "+Input.mousePosition.y);
			if(!startedDrag&&isInside(mousePos,fullInvRect)){//if mouse is in the inventory
				for(int i=0;i<invRects.Length;i++){
					if(isInside (mousePos,invRects[i])&&inventoryList.Count>i){// if mouse is in a slot which has an item in it
						startedDrag=true;
						dragIndex=i;
						break;
					}
				}
			}
		}
		if(Input.GetMouseButtonUp(0)&&startedDrag){//end drag
			startedDrag=false;
			if(isInside(mousePos,fullInvRect)){//if mouse is in inventory
				for(int i=0;i<inventoryList.Count;i++){
					if(i==dragIndex)continue;//makes sure that we do not combine an item with the same slot
					if(isInside (mousePos,invRects[i])){//if mouse is in a slot
						combine(dragIndex,i);
					}
				}
			}
		}
	}
	/**
	 * Draws each box first, then images, then the drag thing of the drag and drop
	 */
	void OnGUI(){
		foreach(Rect r in invRects){
			GUI.Box(r,square);
		}
		for(int i = 0; i < inventoryList.Count; i++){
			Texture2D temp=null;
			switch(inventoryList[i] as string){
			case BRANCH:
				temp= branch;
				break;
			case BUCKET:
				temp=bucket;
				break;
			}
			if(temp!=null)
				GUI.Box(invRects[i],temp);
		}
		if(startedDrag){
			Texture2D temp=null;
			switch((inventoryList[dragIndex]as string)){
			case BRANCH:
				temp=branch;
				break;
			case BUCKET:
				temp=bucket;
				break;
			}
			if(temp==null)return;
			float mouseX=Input.mousePosition.x;
			float mouseY=Screen.height-Input.mousePosition.y;
			GUI.Box(new Rect(mouseX-BOX_WIDTH/2,mouseY-BOX_HEIGHT/2,BOX_WIDTH,BOX_HEIGHT),temp);
		}
	}
	/**
	 * If inventory is not full, add the string representation of an object to inv list
	 */
	void AddItem(string s){
		if(NUM_RECTS>inventoryList.Count)inventoryList.Add(s);	
	}
	/**
	 * Returns whether a point is inside a rect
	 */
	bool isInside(Vector3 v3, Rect rect){
		return v3.x>rect.xMin&&v3.x<=rect.xMax&&v3.y>rect.yMin&&v3.y<=rect.yMax;
	}
	/**
	 * Combine object, someone do this
	 * Also, elsewhere in the script guarantees that there are objects in these 2 indices
	 */
	void combine(int index, int index2){
		//combine objects here
		print("combined!");
	}
}
