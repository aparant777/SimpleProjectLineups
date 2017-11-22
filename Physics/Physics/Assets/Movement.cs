using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float rotateSpeed = 10;
    public float speed = 5;
    private int timesHit = 0;

    public GameObject gear1;
    public GameObject gear2;
    public GameObject cylinder;

    //float speed;
    float width = 4;
    float height = 7;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            gear1.transform.Rotate(0, 40 * Time.deltaTime, 0);
        //    gear1.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, timesHit * 90, 0), Time.deltaTime * speed);
        gear2.transform.Rotate(0, -40 * Time.deltaTime, 0);

            //cylinder.transform.Translate(0, 0, Time.deltaTime * 0.1f); // move forward
           // cylinder.transform.Rotate(0, Time.deltaTime * 0.1f, 0); // turn a little
        }

        // this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, timesHit * 90, 0), Time.deltaTime * speed);
    }
}
