using UnityEngine;
using System.Collections;

public class Camtroller : MonoBehaviour {
	public GameObject player;
	public int lookspeed;
	private Vector3 offset;
	private Vector3 previous;

	private float xtemp;
	private bool doOnce;
	private bool wait;
	private bool lookingup;
	private bool lookingdown;
	private bool lookingright;
	private bool lookingleft;
	
	// Use this for initialization
	void Start () {
		offset = transform.position;
		lookingright = false;
		lookingleft = false;
		lookingdown = false;
		lookingup = false;
		wait = false;
	}
	
	// or use LateUpdate?
	void Update () {
		previous = transform.position;
		transform.position = player.transform.position + offset; // move the camera with the player
		Vector3 change = transform.position - previous; // determine the speeds in each direction

		if(!wait){
			if (transform.eulerAngles.x > 75 && change.x > 0) {
				transform.Rotate (Vector3.up * Time.deltaTime * lookspeed); // looks smoothly
				//xtemp = transform.eulerAngles.x;
				//transform.eulerAngles = new Vector3(xtemp, 90.0f, 90.0f); // 90 90
				lookingright = true;
				doOnce = true;
				//transform.eulerAngles = new Vector3(70, 90, 90);
			}
			else if(transform.eulerAngles.x > 75 && change.x < 0){
				transform.Rotate (Vector3.down * Time.deltaTime * lookspeed); // 270 270
				lookingleft = true;
				doOnce = true;
			}
			else if (transform.eulerAngles.x > 75 && change.z > 0) {
				transform.Rotate (Vector3.left * Time.deltaTime * lookspeed); // 0 0
				lookingup = true;
				doOnce = true;
			}
			else if (transform.eulerAngles.x > 75 && change.z < 0){
				transform.Rotate (Vector3.right * Time.deltaTime * lookspeed); // 180 180
				lookingdown = true;
				doOnce = true;
			}
		}

		// after stopping, look back to center
		if(player.rigidbody.velocity == new Vector3(0.0f,0.0f,0.0f)){
			if(lookingright){ // looking right
				if(doOnce){
					//transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90.0f, 90.0f);
					transform.eulerAngles = new Vector3(75.0f, 90.0f, 90.0f);
					doOnce = false;
					wait = true;
				}
				if(transform.eulerAngles.x < 90){ // need to rotate more to center
					transform.Rotate (Vector3.down * Time.deltaTime * lookspeed); // those directions make sense k.
				}
				else{
					lookingright = false; // done centering.
					wait = false;
				}
			}
			else if(lookingleft){
				if(doOnce){
					transform.eulerAngles = new Vector3(75.0f, 270.0f, 270.0f);
					doOnce = false;
					wait = true;
				}
				if(transform.eulerAngles.x < 90){
					transform.Rotate (Vector3.up * Time.deltaTime * lookspeed);
				}
				else{
					lookingleft = false;
					wait = false;
				}
			}
			else if(lookingup){
				if(doOnce){
					transform.eulerAngles = new Vector3(75.0f, 0.0f, 0.0f);
					doOnce = false;
					wait = true;
				}
				if(transform.eulerAngles.x < 90){
					transform.Rotate (Vector3.right * Time.deltaTime * lookspeed);
				}
				else{
					lookingup = false;
					wait = false;
				}
			}
			else if(lookingdown){
				if(doOnce){
					transform.eulerAngles = new Vector3(75.0f, 180.0f, 180.0f);
					doOnce = false;
					wait = true;
				}
				if(transform.eulerAngles.x < 90){
					transform.Rotate (Vector3.left * Time.deltaTime * lookspeed);
				}
				else{
					lookingdown = false;
					wait = false;
				}
			}
			else{
				transform.eulerAngles = new Vector3(90, 0, 0);
			}
		}

		// camera going crazy patch:
		if(transform.eulerAngles.x < 73 || transform.eulerAngles.x > 92){ // something must have gone wrong
			transform.eulerAngles = new Vector3(90, 0, 0);
		}
	}
}
