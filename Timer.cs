using UnityEngine;
using System.Collections;
/**
 * Henry Wang
 * Keeps track of the time that has elapsed, in real time and gametime.
 * Put in a blank GUIText
 */
public class Timer : MonoBehaviour {
	public const long START_HOUR=6L;
	
	private long startTime;
	public GUIText self;//pass GUIText the script is in into here
	/**
	 * Sets the time when started
	 */
	void Start () {
		startTime=System.DateTime.Now.TimeOfDay.Ticks;
		self.enabled=true;
	}
	/**
	 * Determines and updates gameTime
	 * 10,000,000 ticks is 1 second. Since 1 second in real time is two minutes in gameTime, we divide by 5 million
	 * to get the exact game minute. 
	 * The game starts at 6 AM.
	 */ 
	void Update () {
		long seconds=(System.DateTime.Now.TimeOfDay.Ticks-startTime)/5000000L;//real time elapsed in seconds
		long gameMinutes=seconds;
		long gameHours=gameMinutes/60L+START_HOUR;
		gameMinutes%=60L;
		gameHours%=24L;
		bool am=gameHours<12L;
		if((gameHours%=12L)==0)gameHours=12L;
		string hours=gameHours.ToString();
		string minutes=(string)gameMinutes.ToString();
		hours=gameHours>=10?hours:"0"+hours;
		minutes=gameMinutes>=10?minutes:"0"+minutes;
		self.text="Time: "+hours+":"+minutes+" "+(am?"AM":"PM");
	}
}
