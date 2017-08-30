/* Purpose: Minion logic and respective functionality
   Attached to: NULL*/

using UnityEngine;

public class Zombie : MonoBehaviour {

    public Path path;
    public float minionSpeed;
    private float pathLength;
    private int currrentNodeNumber;
    private Node targetNode;

    void Start() {
        /*get the path length and set the starting index as 0*/
        pathLength = path.Length;
        currrentNodeNumber = 0;      
    }

    void Update() {

        /*get the node from Path array*/
        targetNode = path.GetNode(currrentNodeNumber);
        
        /*Check the minimum distance between minion and node*/
        if (CheckDistance()) {
            /*go to the next node, but check if the node does not increment more than path length*/
            if (currrentNodeNumber < pathLength - 1)
                currrentNodeNumber++;
            else
                return;
        }

        if (currrentNodeNumber >= pathLength) {
            Debug.LogError("Current Node Number exceeded the array length");
            return;
        }

        MoveMinion();
    }

    private void MoveMinion() {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetNode.transform.position, 0.1f * minionSpeed);        
    }

    private bool CheckDistance() {
        return Vector3.Distance(transform.position, targetNode.transform.position) < path.Radius;
    }

    public void Setpath(GameObject ipath) {
        if (ipath != null) {
            path = ipath.GetComponent<Path>();
        } else {
            Debug.LogError("Path is null");
        }
    }   
}