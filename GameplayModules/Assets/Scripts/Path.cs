using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public bool isDebugging = true;
    public float Radius = 2.0f;

    public Node[] nodes;

    public float Length { get { return nodes.Length; } }

    public Node GetNode(int nodeNumber) {
        return nodes[nodeNumber];
    }

    /*Debugging only*/
    void OnDrawGizmos() {
        if (isDebugging == false)
            return;

        for (int i = 0; i < nodes.Length; i++) {
            if (i + 1 < nodes.Length) {
                Debug.DrawLine(nodes[i].transform.position, nodes[i + 1].transform.position, Color.red);
            }
        }
    }
}