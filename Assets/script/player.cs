using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{
	public float RightArrow, LeftArrow, UpArrow;
	Vector3 position;
	bool jump;
	float speedmove=5;
	float speedjump=300;
	

	public AudioClip backgroundt;
	public AudioClip bergerak;
	public AudioClip bom;
	//public Camera MainCamera;
	
	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			audio.clip= bergerak;
			audio.Play();
			position= transform.position+Vector3.left;
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			audio.clip= bergerak;
			audio.Play ();
			position= transform.position+Vector3.right;
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		}
		if (!jump) 
		{
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				//audio.clip=jumpsound;
				//audio.Play();
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GetComponent<Rigidbody> ().AddForce (Vector3.up * speedjump);		
			}
			
			
		}
		
		
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "boxpoint") 
		{
		other.gameObject.audio.Play ();
		//jump = false;;
		Debug.Log ("Tersentuh");
		}
	}

void OnCollisionExit(Collision other){
	//jump = true;
	Debug.Log ("Terlepas");
}
}