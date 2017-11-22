using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour {

	public GameObject cage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other){
	
		if (other.gameObject.tag == "Ball") {
			Rigidbody rigidbody = cage.GetComponent<Rigidbody> ();
			rigidbody.useGravity = true;
		}

	}
}
