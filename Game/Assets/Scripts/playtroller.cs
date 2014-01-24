using UnityEngine;
using System.Collections;

public class playtroller : MonoBehaviour {
	public int speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Get input and move the player
		// Yes I know those directions make none sense. I tried.
		float xmove = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float zmove = Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		rigidbody.AddForce (new Vector3 (xmove, 0.0f, zmove));
	}
}
