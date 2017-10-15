using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

    public List<GameObject> listOfTowers = new List<GameObject>();
    public GameObject tower;

    public void AddTower(GameObject g) {
        listOfTowers.Add(g);
    }

    public void RemoveTower(GameObject g) {
        listOfTowers.Remove(g);
    }

    public void InstntiateTower(Vector3 towerPosition) {
        GameObject tempTower = Instantiate(tower, towerPosition, Quaternion.identity);
        listOfTowers.Add(tempTower);
    }
}
