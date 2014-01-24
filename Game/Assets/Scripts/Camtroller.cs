using UnityEngine;
using System.Collections;

public class Camtroller : MonoBehaviour {
	public GameObject player;
	public int lookspeed;
	private Vector3 offset;
	private Vector3 previous;

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
	}
	
	// or use LateUpdate?
	void Update () {
		previous = transform.position;
		transform.position = player.transform.position + offset; // move the camera with the player
		Vector3 change = transform.position - previous; // determine the speeds in each direction

		if (transform.eulerAngles.x > 75 && change.x > 0) {
			transform.Rotate (Vector3.up * Time.deltaTime * lookspeed); // looks smoothly
			lookingright = true;
			//transform.eulerAngles = new Vector3(70, 90, 90);
		}
		else if(transform.eulerAngles.x > 75 && change.x < 0){
			transform.Rotate (Vector3.down * Time.deltaTime * lookspeed);
			lookingleft = true;
		}
		if (transform.eulerAngles.x > 75 && change.z > 0) {
			transform.Rotate (Vector3.left * Time.deltaTime * lookspeed);
			lookingup = true;
		}
		else if (transform.eulerAngles.x > 75 && change.z < 0){
			transform.Rotate (Vector3.right * Time.deltaTime * lookspeed);
			lookingdown = true;
		}

		// after stopping, look back to center
		if(player.rigidbody.velocity == new Vector3(0.0f,0.0f,0.0f)){
			if(lookingright){ // looking right
				if(transform.eulerAngles.x < 90){ // need to rotate more to center
					transform.Rotate (Vector3.down * Time.deltaTime * lookspeed); // those directions make sense k.
				}
				else lookingright = false; // done centering.
			}
			else if(lookingleft){
				if(transform.eulerAngles.x < 90){
					transform.Rotate (Vector3.up * Time.deltaTime * lookspeed);
				}
				else lookingleft = false;
			}
			else if(lookingup){
				if(transform.eulerAngles.x < 90){
					transform.Rotate (Vector3.right * Time.deltaTime * lookspeed);
				}
				else lookingup = false;
			}
			else if(lookingdown){
				if(transform.eulerAngles.x < 90){
					transform.Rotate (Vector3.left * Time.deltaTime * lookspeed);
				}
				else lookingdown = false;
			}
			else{
				transform.eulerAngles = new Vector3(90, 0, 0);
			}
		}
	}
}
