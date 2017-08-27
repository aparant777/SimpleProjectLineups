using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    public bool isVisited;


    public bool HasVisited() { return isVisited; }

	// Use this for initialization
	void Start () {
        isVisited = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
