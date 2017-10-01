using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float moveSpeed;

    private void Update() {
        gameObject.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }
}
