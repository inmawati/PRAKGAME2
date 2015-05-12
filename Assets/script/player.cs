using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour 
{
	public Text score;
	public float RightArrow, LeftArrow, UpArrow;
	Vector3 position;
	bool jump;
	float speedmove=5;
	float speedjump=300;

	public Camera MainCamera;
	

	public AudioClip backgroundt;
	public AudioClip bergerak;
	public AudioClip bom;
	//public Camera MainCamera;
	
	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			audio.clip= bergerak;
			audio.Play();
			transform.eulerAngles= new Vector3(0,180,0);
			position= transform.position+Vector3.left;
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			audio.clip= bergerak;
			audio.Play ();
			transform.eulerAngles= new Vector3(0,0,0);
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
		if (other.gameObject.tag == "boxpoint") {
		other.gameObject.audio.Play ();
		BoxCollider box= GetComponent<BoxCollider>();
		box.isTrigger = true;
		//jump = false;;
		}

		if (other.gameObject.tag == "point") {
			int point = int.Parse (score.text) + 10;
			score.text = point.ToString ();
			Destroy (other.gameObject);//hancurkan objek
		}
	}

void OnCollisionExit(Collision other){
	//jump = true;
	Debug.Log ("Terlepas");
}
}