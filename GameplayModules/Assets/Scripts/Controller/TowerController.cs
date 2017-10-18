using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    public GameObject temp;
    public float towerSpeed;

	void Update () {
        float horizontalValue = Input.GetAxis("Horizontal");
        float frontalvalue = Input.GetAxis("Vertical");

        //temp.transform.position = temp.transform.position + new Vector3(horizontalValue * Time.deltaTime * towerSpeed, 0, frontalvalue * Time.deltaTime * towerSpeed); 
	}
}
