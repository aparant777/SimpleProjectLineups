using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {


    public List<Node> path;
    public Node currentNode;
    public int currentNodeNumber;

    void Start () {
        currentNodeNumber = 0;
        currentNode = path[currentNodeNumber];

        Debug.Log("Current node number is " + currentNodeNumber);
        Debug.Log("Current node is " + path[currentNodeNumber]);

    }
	
	void Update () {
        
        for(int i = 0; i < path.Count - 1;) {
            if(currentNode.HasVisited() == true) {
                Debug.Log("Current Node" + currentNode.gameObject.name + "is visited as: " + currentNode.isVisited);
                i++;
                currentNodeNumber = i;
                currentNode = path[currentNodeNumber];
            } else {
                if (Vector3.Distance(gameObject.transform.position, currentNode.gameObject.transform.position) < 1.0f) { 
                    currentNode.isVisited = true;
                    Debug.Log("Finally " + currentNode.gameObject.name + " is visited");
                    i++;
                    currentNodeNumber = i;
                    currentNode = path[currentNodeNumber];
                    Debug.Log("currentNode number is " + currentNodeNumber);
                    Debug.Log("Current Node is now " + currentNode.gameObject.name);                    
                }
                else {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, currentNode.transform.position, 0.1f * Time.deltaTime);
                }
            }           
        }
    }    
    


    void MoveToTargetLocation(Vector3 currentPosition, Vector3 targetPosition) {
        float movementSpeed = 5.0f;

        if(Vector3.Distance(currentPosition,targetPosition) > 0.1f) {
            Vector3 directionToTravel = targetPosition - currentPosition;
            directionToTravel.Normalize();

            gameObject.transform.Translate(
                directionToTravel.x * movementSpeed * Time.deltaTime,
                directionToTravel.y * movementSpeed * Time.deltaTime,
                directionToTravel.z * movementSpeed * Time.deltaTime
                );
        }


    }
}
