using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

    public bool isVisited;

    public bool HasVisited() { return isVisited; }
	void Start () { isVisited = false; }
}
